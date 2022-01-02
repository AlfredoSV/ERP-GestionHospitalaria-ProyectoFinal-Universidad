using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Presentation.WebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UsuariosController : Controller
    {
        private readonly UsuariosDbContext _usuariosDbContext;
        public UsuariosController(IConfiguration configuration)
        {
            _usuariosDbContext = new UsuariosDbContext(configuration.GetConnectionString("DefaultConnection"));
            
        }

        public IActionResult Index()
        {
            
            return View(_usuariosDbContext.List());
        }
    }
}
