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
    class wsLista
    {
        HttpClient http;
        public async Task<List<models.Listas>> listalist()
        {
            List<models.Listas> listalist = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/sii/lista/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listalist = new List<Listas>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("lista").ToList();

                Listas lista;
                foreach (var kar in arrJson)
                {
                    lista = new Listas();
                    lista = JsonConvert.DeserializeObject<Listas>(kar.ToString());
                    listalist.Add(lista);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }
            return listalist;
        }
    }
}

