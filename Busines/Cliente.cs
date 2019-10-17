using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines
{
    public class Cliente

    {
        public string Nome { get; set; }
        public List<Cliente> Clientes()

        {
            var clientes = new List<Cliente>();
            clientes.Add(new Cliente() { Nome = "Danilo" });
            return clientes;



        }
    }
}
