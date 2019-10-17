using Busines;
using System.Web.Mvc;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Novo()
        {



            ViewBag.Paginas = new Pagina().Lista(); //vai buscar as informações no banco de dados
            return View();
        }

        public ActionResult About(int id)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}