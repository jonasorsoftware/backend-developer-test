using Busines;
using System.Web.Mvc;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginaController : Controller
    {
        public ActionResult Index()
        {



            ViewBag.Paginas = new Pagina().Lista();
            return View();
        }

     
        
    }
}