using Busines;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class CepController : Controller
    {
        public ActionResult Index()
        {


            ViewBag.Cep = Busines.Cep.Busca("04864100");
            return View();
        }

        public string Consulta(string cep)
        {
            var cepObj = Busines.Cep.Busca(cep);
            return new JavaScriptSerializer().Serialize(cepObj);

        }
    }
}