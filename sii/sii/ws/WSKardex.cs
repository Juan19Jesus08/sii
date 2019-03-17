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
    class WSKardex
    {
        HttpClient http;
        public async Task<List<models.Kardex>> listaKardex()
        {
            List<models.Kardex> listaKardex = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/sii/kardex/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaKardex = new List<Kardex>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("kardex").ToList();

                Kardex kardex;
                foreach (var kar in arrJson)
                {
                    kardex = new Kardex();
                    kardex = JsonConvert.DeserializeObject<Kardex>(kar.ToString());
                    listaKardex.Add(kardex);
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

