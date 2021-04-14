using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SaludCore.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult Index()
        {
            return View(Datos.ObtenerRegistro(7, "2017-01-27"));
        }
    }
}