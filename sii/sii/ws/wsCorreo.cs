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
    class wsCorreo
    {
        HttpClient http;
        public async Task<List<models.Correo>> listacorreo()
        {
            List<models.Correo> listacorreo = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/sii/correo/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listacorreo = new List<Correo>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("correo").ToList();

                Correo correo;
                foreach (var kar in arrJson)
                {
                    correo = new Correo();
                    correo = JsonConvert.DeserializeObject<Correo>(kar.ToString());
                    listacorreo.Add(correo);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }
            return listacorreo;
        }
    }
}

