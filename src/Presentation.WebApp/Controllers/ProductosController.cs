using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.WebApp.Models;
using Application.IServicios;

namespace Presentation.WebApp.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private readonly IServicioProducto _servicioProducto;
        private readonly IServicioCatalogos _servicioCatalogos;
        private readonly IFileConvertService _fileConvertService;
        public ProductosController(IConfiguration configuration, IFileConvertService fileConvertService,
                                   IServicioCatalogos servicioCatalogos, IServicioProducto servicioProducto)
        {
            _servicioProducto = servicioProducto;
            _servicioCatalogos = servicioCatalogos;
            _fileConvertService = fileConvertService;
        }

        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult Index()
        {
            CargarTipoProductos();
            return View(_servicioProducto.ConsultarProductos());
        }

        [HttpPost]
        public IActionResult ListarProductos()
        {
            return Json(_servicioProducto.ConsultarProductos());
        }

        [Authorize(Roles = "Admin,Doctor,Enfermera")]
        [HttpGet]
        public IActionResult Details()
        {
            return View("Details", _servicioProducto.ConsultarProductos());
        }

        [HttpPost]
        public IActionResult Details(Guid id)
        {
            return Json(_servicioProducto.ConsultarDetalleProducto(id));
        }

        [HttpPost]
        public IActionResult DetailsEdit(Guid id)
        {
            return Json(_servicioProducto.ConsultarDetalleProducto(id));
        }

        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult Create()
        {
            CargarTipoProductos();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto data)
        {
            CargarTipoProductos();
            _servicioProducto.GuardarNuevoProducto(Domain.Producto.Create(data.Nombre, data.Descripcion,
                data.IdTipoProducto, data.Precio, data.Cantidad, _fileConvertService.ConvertToBase64(data.Foto.OpenReadStream())));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Producto data)
        {

            string fotografia = data.Foto == null ? 
                _servicioProducto.ConsultarDetalleProducto(data.Id).Foto :
                _fileConvertService.ConvertToBase64(data.Foto.OpenReadStream());

            Domain.Producto producto = Domain.Producto.Create
                (data.Id, data.Nombre, data.Descripcion, data.IdTipoProducto,
                data.Precio, data.Cantidad, fotografia);

            bool editarPro = _servicioProducto.EditarProducto(producto);

            return Json(new { sal = editarPro });

        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View(_servicioProducto.ConsultarProductos());
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var seElimino = _servicioProducto.EliminarProducto(id);
            return Json(new { seElimino });
        }

        private void CargarTipoProductos()
        {
            List<SelectListItem> listaTiposProductos = new List<SelectListItem>();
            foreach (var estado in _servicioCatalogos.ConsultarTiposProductos())
            {
                listaTiposProductos.Add(new SelectListItem { Value = 
                    estado.IdTipo.ToString(), Text = estado.Nombre });
            }
            ViewBag.tiposProductos = listaTiposProductos;
        }
    }
}
