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
    class wsCarga
    {
        HttpClient http;
        public async Task<List<models.Carga>> listaKardex()
        {
            List<models.Carga> listaKardex = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/sii/carga/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaKardex = new List<Carga>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("carga").ToList();

                Carga carga;
                foreach (var kar in arrJson)
                {
                    carga = new Carga();
                    carga = JsonConvert.DeserializeObject<Carga>(kar.ToString());
                    listaKardex.Add(carga);
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

