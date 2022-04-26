using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Presentation.WebApp.Models;
using System.Diagnostics;
using System.Linq;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Application.IServicios;
using Domain.IRepositorios;
using Microsoft.AspNetCore.Identity;
using System;

namespace Presentation.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Doctor,Enfermera")]
    public class HomeController : Controller
    {
        private readonly IServicioCitas _servicioCitas;

        private readonly IServicioCatalogos _servicioCatalogos;
        private readonly IServicioPaciente _servicioPaciente;
        private readonly RepositorioDoctores _doctoresDbContext;
        private readonly IServicioUsuarios _servicioUsuarios;
        private readonly IServicioProducto _servicioProducto;
        private readonly IFileConvertService _fileConvertService;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager, IFileConvertService fileConvertService, IServicioCitas servicioCitas, IServicioPaciente servicioPaciente, IServicioCatalogos servicioCatalogos, IServicioUsuarios servicioUsuarios,IServicioProducto servicioProducto)
        {
            _servicioPaciente = servicioPaciente;
            _servicioCitas = servicioCitas;
            _servicioCatalogos = servicioCatalogos;
            _servicioUsuarios = servicioUsuarios;
            _servicioProducto = servicioProducto;
            _fileConvertService = fileConvertService;
            _userManager = userManager;
        }


        public IActionResult Index()
        {

            var data = _servicioPaciente.ConsultarPacientesPorEstadoCivil();
            // ToDo
            ViewBag.EstadosCiviles = data.Select(x => x.Metrica);

            ViewBag.DataPacientesEsta = data.Select(x => x.Total);

            ////////////////Por especialidad


            var dataDoc = _servicioCitas.ConsultarCitasGraficas();


            ViewBag.Estaus = dataDoc.Select(x => x.Metrica);

            ViewBag.TotalPorEstatus = dataDoc.Select(x => x.Total);

            ///////////////////////////////////////////////////////////


            var dataPacS = _servicioPaciente.ConsultarPacientesPorProfesion();


            ViewBag.Sangre = dataPacS.Select(x => x.Metrica);

            ViewBag.TotalPorSangre = dataPacS.Select(x => x.Total);

            ////////////////////////////////////////////////////
            ///
            var dataTipoPro = _servicioProducto.ConsultarProductos().GroupBy(info => info.NombreTipo)
          .Select(group => new
          {
              Metric = group.Key,
              Count = group.Count()
          })
          .OrderBy(x => x.Metric);


            ViewBag.dataTipoPro = dataTipoPro.Select(x => x.Count);



            return View();
        }

        [HttpGet]
        public IActionResult MisDatos()
        {
            try
            {
                Catalogos();
                string nombreUsuario = HttpContext.User.Identity.Name;
                var idUsuario = Guid.Parse(_userManager.Users.ToList().Where(u => u.UserName == nombreUsuario).FirstOrDefault().Id);

                return View("MisDatos", _servicioUsuarios.DetalleUsuario(idUsuario));
            }
            catch (Exception exception)
            {

                return View("Error");
            }
            
           
        }

        [HttpPost]
        public IActionResult CambiarRol(string usuario, string rol)
        {

            var seActualizo = _servicioUsuarios.ActualizarRolDeUsuario(usuario, rol);

            return Json(seActualizo);
        }

        [HttpPost]
        public IActionResult EditarMiInformacion(Domain.UsuarioInfo data)
        {

            string nombreUsuario = HttpContext.User.Identity.Name;
            var idUsuario = Guid.Parse(_userManager.Users.ToList().Where(u => u.UserName == nombreUsuario).FirstOrDefault().Id);

            if (ModelState.IsValid)
            {
                data.FotoT = data.FotoFile == null ? _servicioUsuarios.DetalleUsuario(idUsuario).FotoT : _fileConvertService.ConvertirABase64(data.FotoFile.OpenReadStream()); ;
                
                var seActualizo = _servicioUsuarios.ActualizarDatosUsuario(data, nombreUsuario);

                ViewBag.seActualizo = seActualizo;

                return View("MisDatos", _servicioUsuarios.DetalleUsuario(idUsuario));
            }

            return View("MisDatos", _servicioUsuarios.DetalleUsuario(idUsuario));

        }

        private void Catalogos()
        {
            List<SelectListItem> listaEstadosCiviles = new List<SelectListItem>();

            foreach (var estado in _servicioCatalogos.ConsultarCatalogoEstadoCivil())
            {
                listaEstadosCiviles.Add(new SelectListItem { Value = estado.IdEstado.ToString(), Text = estado.Nombre_Estado });
            }

            ViewBag.estadosCiviles = listaEstadosCiviles;

        }
    }
}
