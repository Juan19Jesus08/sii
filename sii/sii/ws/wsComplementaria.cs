using sii.models;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace sii.ws
{
    class wsComplementaria
    {
        HttpClient http;
        public async Task<List<models.Complementaria>> listaKardex()
        {
            List<models.Complementaria> listaKardex = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/sii/complemento/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaKardex = new List<Complementaria>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("complemento").ToList();

                Complementaria complemento;
                foreach (var kar in arrJson)
                {
                    complemento = new Complementaria();
                    complemento = JsonConvert.DeserializeObject<Complementaria>(kar.ToString());
                    listaKardex.Add(complemento);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }
            return listaKardex;
        }
    }
}

