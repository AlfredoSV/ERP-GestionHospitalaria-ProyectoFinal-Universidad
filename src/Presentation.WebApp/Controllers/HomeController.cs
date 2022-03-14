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

namespace Presentation.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Doctor,Enfermera")]
    public class HomeController : Controller
    {
        private readonly IServicioCitas _servicioCitas;

        private readonly IServicioCatalogos _servicioCatalogos;
        private readonly IServicioPaciente _servicioPaciente;
        private readonly RepositorioDoctores _doctoresDbContext;
        private readonly UsuariosDbContext _usuariosDbContext;
        private readonly ProductosDbContext _productosDbContext;
        private readonly IFileConvertService _fileConvertService;

        public HomeController(IConfiguration configuration, IFileConvertService fileConvertService, IServicioCitas servicioCitas, IServicioPaciente servicioPaciente, IServicioCatalogos servicioCatalogos)
        {
            _servicioPaciente = servicioPaciente;
            _servicioCitas = servicioCitas;
            _servicioCatalogos = servicioCatalogos;
            _doctoresDbContext = new RepositorioDoctores(configuration.GetConnectionString("DefaultConnection"));
            _usuariosDbContext = new UsuariosDbContext(configuration.GetConnectionString("DefaultConnection"));
            _productosDbContext = new ProductosDbContext(configuration.GetConnectionString("DefaultConnection"));
            _fileConvertService = fileConvertService;
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
            Catalogos();
            string userName = HttpContext.User.Identity.Name;
            
            return View("MisDatos", _usuariosDbContext.Deatail(userName));
        }

        [HttpPost]
        public IActionResult CambiarRol(string usuario, string rol)
        {

            var seActualizo = _usuariosDbContext.CambiarRol(usuario, rol);

            return Json(seActualizo);
        }

        public IActionResult EditarMiInformacion(Domain.UsuarioInfo data)
        {

            string usuario = HttpContext.User.Identity.Name;
            
            if (ModelState.IsValid)
            {
                data.FotoT = data.FotoFile == null ? _usuariosDbContext.Deatail(usuario).FotoT : _fileConvertService.ConvertirABase64(data.FotoFile.OpenReadStream()); ;
                
                var seActualizo = _usuariosDbContext.EditarMisDatos(data, usuario);

                ViewBag.seActualizo = seActualizo;

                return View("MisDatos", _usuariosDbContext.Deatail(usuario));
            }

            return View("MisDatos", _usuariosDbContext.Deatail(usuario));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
