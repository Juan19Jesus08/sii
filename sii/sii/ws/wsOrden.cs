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
    class wsOrden
    {
        HttpClient http;
        public async Task<List<models.Orden>> listaAlumno()
        {
            List<models.Orden> listaAlumno = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");
                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/sii/orden/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaAlumno = new List<models.Orden>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("orden").ToList();

                models.Orden orden;
                foreach (var al in arrJson)
                {
                    orden = new models.Orden();
                    orden = JsonConvert.DeserializeObject<models.Orden>(al.ToString());
                    
                    Settings.Settings.fecha_ins = orden.fecha_ins;
                    

                    listaAlumno.Add(orden);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }
            return listaAlumno;
        }
    }
}

