using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(ILogger<HomeController> logger , IRepositorioProyectos repositorioProyectos,IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.localizer = localizer;
        }

        public IActionResult Index()
        {
           
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

         public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }



        public IActionResult Contacto() { 
        
            
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contactoViewModel)
        {
            return RedirectToAction("Gracias");
           
        }

        public IActionResult Gracias()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CambiarIdioma(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(5) }
            );
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index"); // Fallback to a default action or page
            }
            return LocalRedirect(returnUrl);
        }
        public IActionResult Bom()
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
