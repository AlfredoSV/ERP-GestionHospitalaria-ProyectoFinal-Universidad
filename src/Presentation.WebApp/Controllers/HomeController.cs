using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Presentation.WebApp.Models;
using System.Diagnostics;
using System.Linq;
using Domain;
using Infrastructure;
using Application;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using Application.IServicios;

namespace Presentation.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Doctor,Enfermera")]
    public class HomeController : Controller
    {
        private readonly IServicioCitas _servicioCitas;

        private readonly RepositorioCatalogos _catalogosDbContext;
        private readonly IServicioPaciente _servicioPaciente;
        private readonly RepositorioDoctores _doctoresDbContext;
        private readonly UsuariosDbContext _usuariosDbContext;
        private readonly ProductosDbContext _productosDbContext;
        private readonly IFileConvertService _fileConvertService;

        public HomeController(IConfiguration configuration, IFileConvertService fileConvertService, IServicioCitas servicioCitas,IServicioPaciente servicioPaciente)
        {
            _servicioPaciente = servicioPaciente;
            _servicioCitas = servicioCitas;
            _catalogosDbContext = new RepositorioCatalogos(configuration.GetConnectionString("DefaultConnection"));
            _doctoresDbContext = new RepositorioDoctores(configuration.GetConnectionString("DefaultConnection"));
            _usuariosDbContext = new UsuariosDbContext(configuration.GetConnectionString("DefaultConnection"));
            _productosDbContext = new ProductosDbContext(configuration.GetConnectionString("DefaultConnection"));
            _fileConvertService = fileConvertService;
        }


        public IActionResult Index()
        {


            var data = _servicioPaciente.ConsultarPacientesBD().GroupBy(info => info.EstadoCivil)
                        .Select(group => new
                        {
                            Metric = _catalogosDbContext.ListCatEstadoCivil().Where(x => x.IdEstado == group.Key).Select(x => x.Nombre_Estado).FirstOrDefault(),
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Metric);
            // ToDo
            ViewBag.EstadosCiviles = data.Select(x => x.Metric);

            ViewBag.DataPacientesEsta = data.Select(x => x.Count);

            ////////////////Por especialidad
            ///

            var dataDoc = _servicioCitas.ConsultarCitasGraficas().GroupBy(info => info.EstatusCita)
                        .Select(group => new
                        {
                            Metric = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Metric);


            ViewBag.Estaus = dataDoc.Select(x => x.Metric);

            ViewBag.TotalPorEstatus = dataDoc.Select(x => x.Count);

            ///////////////////////////////////////////////////////////
            ///

            var dataPacS = _servicioPaciente.ConssultarPacientesPorProfesionBD().GroupBy(info => info.NombreProfesion)
                      .Select(group => new
                      {
                          Metric = group.Key,
                          Count = group.Count()
                      })
                      .OrderBy(x => x.Metric);


            ViewBag.Sangre = dataPacS.Select(x => x.Metric);

            ViewBag.TotalPorSangre = dataPacS.Select(x => x.Count);

            ////////////////////////////////////////////////////
            ///
            var dataTipoPro = _productosDbContext.List().GroupBy(info => info.NombreTipo)
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
            ViewBag.seActualizo = null;
            List<SelectListItem> listaEstadosCiviles = new List<SelectListItem>();

            foreach (var estado in _catalogosDbContext.ListCatEstadoCivil())
            {
                listaEstadosCiviles.Add(new SelectListItem { Value = estado.IdEstado.ToString(), Text = estado.Nombre_Estado });
            }
            ViewBag.estadosCiviles = listaEstadosCiviles;
            string userName = HttpContext.User.Identity.Name;


            return View("MisDatos", _usuariosDbContext.Deatail(userName));
        }

        [HttpPost]
        public IActionResult CambiarRol(string username, string rol)
        {

            var seActualizo = _usuariosDbContext.CambiarRol(username, rol);

            return Json(seActualizo);
        }

        public IActionResult EditarMiInformacion(Domain.UsuarioInfo data)
        {
            List<SelectListItem> listaEstadosCiviles = new List<SelectListItem>();

            foreach (var estado in _catalogosDbContext.ListCatEstadoCivil())
            {
                listaEstadosCiviles.Add(new SelectListItem { Value = estado.IdEstado.ToString(), Text = estado.Nombre_Estado });
            }
            ViewBag.estadosCiviles = listaEstadosCiviles;
            string userName = HttpContext.User.Identity.Name;
            string foto = string.Empty;
            if (ModelState.IsValid)
            {
                if (data.FotoFile == null)
                {
                    foto = _usuariosDbContext.Deatail(userName).FotoT;
                }
                else
                {
                    foto = _fileConvertService.ConvertirABase64(data.FotoFile.OpenReadStream());
                }
                data.FotoT = foto;
                var seActualizo = _usuariosDbContext.EditarMisDatos(data, userName);

                ViewBag.seActualizo = seActualizo;

                return View("MisDatos", _usuariosDbContext.Deatail(userName));
            }

            return View("MisDatos", _usuariosDbContext.Deatail(userName));

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
