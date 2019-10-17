using Busines;
using System;
using System.Web.Mvc;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Paginas = new Pagina().Lista();
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public void Criar()
        {
            DateTime data;
            DateTime.TryParse(Request["data"], out data);
            var pagina = new Pagina();
            pagina.Nome = Request["nome"];
            pagina.Data = data;
            pagina.Conteudo = Request["conteudo"];
            pagina.Save();
            Response.Redirect("/paginas");
        }
        public void Excluir( int id) // volta as informações para meu controle 3 fase 
        {
            Pagina.Excluir(id);
           Response.Redirect("/paginas"); // manda as informações novas para pagina
        }

        public ActionResult Editar(int Id) //vai receber os parametros da " ROTA "

        {
            var pagina = Pagina.BuscarPorId(Id);// vai retornar as informações da instancia 
            ViewBag.Pagina = pagina; //buscar as informações  referehte ao formulario 
            return View();
        }


        public ActionResult Preview(int Id)

        {
            var pagina = Pagina.BuscarPorId(Id);
            ViewBag.Pagina = pagina;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Alterar(int id)
        {
            try
            {
                var pagina = Pagina.BuscarPorId(id);

                DateTime data;
                DateTime.TryParse(Request["data"], out data);

                pagina.Nome = Request["nome"];
                pagina.Data = data;
                pagina.Conteudo = Request["conteudo"];
                pagina.Save();

                TempData["sucesso"] = "Pagina alterada com sucesso";
            }
            catch
            {
                TempData["erro"] = "Pagina não pode ser alterada";
            }

            Response.Redirect("/paginas");

        }

    }

}
