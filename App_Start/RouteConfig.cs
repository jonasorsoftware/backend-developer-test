using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)

        {



            routes.MapRoute(
               "sobre",
               "sobre",

                new { controller = "Home", action = "about" }

               );

            routes.MapRoute(
                   "paginas_novo",
                   "paginas_novo",

                  new { controller = "Paginas", action = "Index" }
                   );
            routes.MapRoute(
              "paginas_criar",
              "paginas/criar",

                  new { controller = "Paginas", action = "criar" }
                      

              );

            routes.MapRoute(
                 "paginas_editar",
                   "paginas/{Id}/editar",

                   new { controller = "Paginas", action = "Editar", id = 0 }

             );
            routes.MapRoute(
              "paginas_excluir",
                "paginas/{id}/excluir",

                new { controller = "Paginas", action = "excluir", id = 0 }

          );
            routes.MapRoute(
            "paginas_preview",
              "paginas/{id}/preview",

              new { controller = "Paginas", action = "Preview", id = 0 }

        );
            routes.MapRoute(
                "paginas_alterar",
                  "paginas/{id}/alterar",

                  new { controller = "Paginas", action = "Alterar", id = 0 }

            );
            routes.MapRoute(
                  "contato",
                    "contato",

                    new { controller = "Home", action = "Contact" }

              );
            routes.MapRoute(
                  "consulta_cep",
                    "consulta_cep",

                    new { controller = "Cep", action = "index" }

              );




            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
