using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines
{
   public class Pagina
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Conteudo { get; set; }
    public DateTime Data { get; set; }


    public List<Pagina>Lista()// vai listar o (Objeto Pagina)ele vai retornar no proprio Lista() " dos objetos criados "
    {
            var lista = new List<Pagina>();
            var paginaDb = new DataBase.Pagina();// criar um novo banco, com as informações das Paginas      
            foreach(DataRow row in paginaDb.Lista().Rows) // retornar as informações da instancia criada 


            {
                var pagina = new Pagina(); //foi criado uma variavel pagina para o obejto Pagina
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Conteudo = row["conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);

                lista.Add(pagina); // Na variavel lista vai preencher a pagina que foi criado na instancia 
            }
            return lista; // retornar as informações completa 
        }

        public static Pagina BuscarPorId(int Id)
        {
            var pagina = new Pagina();
            var paginaDb = new DataBase.Pagina();   
            foreach (DataRow row in paginaDb.BuscaPorId(Id).Rows) 

            {
                pagina.Id = Convert.ToInt32(row["Id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Conteudo = row["conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);
            }
            return pagina; // retornar as informações completa 
        }

        public void Save()
        {
            new DataBase.Pagina().Salvar(this.Id, this.Nome, this.Conteudo, this.Data);
        }
        public static void Excluir(int id)
        {
            new DataBase.Pagina().Excluir(id);// volta a informação do banco de dados 2
        }
    }

}

