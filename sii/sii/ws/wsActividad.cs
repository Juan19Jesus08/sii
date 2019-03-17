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
    class wsActividad
    {
       
        HttpClient http;
        public async Task<List<models.Actividad>> listaKardex()
        {
            List<models.Actividad> listaKardex = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/sii/actividadext/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaKardex = new List<Actividad>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("actividadext").ToList();

                Actividad actividad;
                foreach (var kar in arrJson)
                {
                    actividad = new Actividad();
                    actividad = JsonConvert.DeserializeObject<Actividad>(kar.ToString());
                    Settings.Settings.actividad = actividad.actividad;
                    Settings.Settings.rama = actividad.rama;
                    Settings.Settings.grupo = actividad.grupo;
                    Settings.Settings.lugar = actividad.lugar;
                    Settings.Settings.responsable = actividad.responsable;

                    listaKardex.Add(actividad);
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

