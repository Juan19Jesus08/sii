using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sii.models;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Linq;


namespace sii.ws
{
    class wsInscripcion
    {
        public async Task<Boolean> postInscripcion(String calif1,String calif2,String calif3,String calif4)
        {
            Boolean flag = false;
            List<Inscripcion> lista = new List<Inscripcion>();
            try
            {

            
                
                //var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
                Inscripcion insc = new Inscripcion();
              
                insc.cvemat = Settings.Settings.clave_mat;
                insc.nogpo = Settings.Settings.clave_grupo;
                insc.nocont = Settings.Settings.nocont;
                insc.calificacion1 = calif1;
                insc.calificacion2 = calif2;
                insc.calificacion3 = calif3;
                insc.calificacion4 = calif4;

                var json = JsonConvert.SerializeObject(insc);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://192.168.1.81:5000");
                // var authData = string.Format("{0}:{1}", "root", "root");
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                //var resp = await httpClient.GetAsync("SIIWS_PATM/api/wslista/getlista/" + Settings.idStudent + "/" + Settings.token);
                var resp = await httpClient.PostAsync("/sii/inscribir/" + Settings.Settings.token, content);
                if (resp.IsSuccessStatusCode)
                    flag = true;

            }
            catch (Exception e)
            {

              
            }

            return flag;
        }

       
    }
}
