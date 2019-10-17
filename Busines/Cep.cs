using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Busines
{
    public class Cep
    {

        public String CEP { get; set; }
        public String Endereco { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }


        public static Cep Busca(string cep)
        {
            var cepObj = new Cep();

            var url = "http://apps.widenet.com.br/busca-cep/api/cep.json?code=" + cep;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string json = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            JsonCepObject cepJson = json_serializer.Deserialize<JsonCepObject>(json);

            cepObj.CEP = cepJson.code;
            cepObj.Endereco = cepJson.address;
            cepObj.Bairro = cepJson.district;
            cepObj.Cidade = cepJson.city;
            cepObj.Estado = cepJson.state;
            return cepObj;
        }
    }



    public class JsonCepObject
    {
        public string code { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
    }
}

