using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portafolio
{
    public class Constantes
    {
        public static readonly SelectListItem[] CulturasUISoportadas = new SelectListItem[]
        {
            new SelectListItem { Value = "es", Text = "Español" },
            new SelectListItem { Value = "en", Text = "English" },
            
        };
    }
}
