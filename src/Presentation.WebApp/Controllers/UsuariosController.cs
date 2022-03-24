using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Application.IServicios;

namespace Presentation.WebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UsuariosController : Controller
    {
        private readonly IServicioUsuarios _servicioUsuarios;
        public UsuariosController(IConfiguration configuration, IServicioUsuarios servicioUsuarios)
        {
            _servicioUsuarios = servicioUsuarios;
            
        }

        public IActionResult Index()
        {
            
            return View(_servicioUsuarios.ListarUsuarios());
        }
    }
}
