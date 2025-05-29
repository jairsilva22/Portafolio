using Microsoft.Extensions.Localization;
using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }

    public class RepositorioProyectos : IRepositorioProyectos
    {
        private readonly IStringLocalizer<RepositorioProyectos> localizer;

        public RepositorioProyectos(IStringLocalizer<RepositorioProyectos> localizer)
        {
            this.localizer = localizer;
        }
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto {
                    Titulo = "Gym  🏋️‍♂️ ",
                    Descripcion = localizer["DescripcionGym"],
                    Herramientas ="C#, ASP.NET Core,Dapper, SQL Server, Bootstrap, JavaScript",
                    Link = "https://github.com/jairsilva22/GYM?tab=readme-ov-file",
                    ImagenURL="/imagenes/GYM.png"
                },
                new Proyecto {
                    Titulo = "Help Desk",
                    Descripcion =localizer["DescripcionHelpDesk"],
                    Herramientas ="ASP.NET Core 9,Entity Framework Core,SignalR,SQL Server,Bootstrap,JavaScript,HTML5,CSS3,Identity",
                    Link = "https://github.com/jairsilva22/HelpDesk",
                    ImagenURL="/imagenes/nyt.png"
                }, 

                   new Proyecto {
                    Descripcion = localizer["DescripcionSNTSS"],
                    Herramientas ="HTML,CSS,Tailwind,JS",
                    Link = "https://incomparable-kringle-ab1f9f.netlify.app/",
                    ImagenURL="/imagenes/IMSS.png"
                },

                    new Proyecto {
                    Titulo = "Bom",
                    Descripcion =localizer["DescripcionBom"],
                    Herramientas ="ASP.NET 6,Dapper,SQL Server,Bootstrap,JavaScript,HTML5,CSS3",
                    Link = "/Home/Bom",
                    ImagenURL="/imagenes/nyt.png"
                },

                   new Proyecto {
                    Descripcion = "BataBit",
                    Herramientas ="HTML,CSS",
                    Link = "https://bata-bit.vercel.app/",
                    ImagenURL="/imagenes/batabit.png"
                },




            };

        }
    }
}
