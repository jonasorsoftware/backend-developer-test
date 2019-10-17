using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Pagina
    {
        private string sqlConn()
        {
           return ConfigurationManager.AppSettings["sqlConn"];//ConfigurationManager vai retornar as informações que foi criado na string de conexão
        }

        public DataTable Lista()// DataTable vai armazenar as informações na variavel Lista()

        {
            using(SqlConnection connection = new SqlConnection(sqlConn())) // acessando o banco de dados 

            {      
                string queryString = "select * from paginas"; //comando para buscar as informações das paginas da internet
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
            
                

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable(); //cria o adapter
                adapter.Fill(table);//preenche as informaçoes 
                return table;

            }

        }
    }
}
