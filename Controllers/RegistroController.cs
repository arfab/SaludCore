using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaludCore.Models;

namespace SaludCore.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult Index()
        {
            return View(Datos.ObtenerRegistro(7, "2017-01-27"));
        }


      [HttpGet]
      public IActionResult Agregar()
        {

            ViewBag.ListOfComidas = Datos.ObtenerComidas();

            return View();
        }

    [HttpPost]
    public IActionResult Agregar([Bind] Registro registro)
    {
        string sret;

        int? usuario_id = HttpContext.Session.GetInt32("USER_ID");

        if (ModelState.IsValid)
        {
            sret = Datos.InsertarRegistro(registro);
            if (sret == "")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = sret;
            }
        }

      


        return View();
    }

   }

}