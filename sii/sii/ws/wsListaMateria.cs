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
    class wsListaMateria
    {
        HttpClient http;
        public async Task<List<models.ListaMateria>> listaMateria()
        {
            List<models.ListaMateria> listaMateria = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");

                //var authData = string.Format("{0}:{1}", "intertecs", "1nt3rt3c5");                        //auth
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData)); //auth
                //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var result = await http.GetAsync("/sii/listmat/" + Settings.Settings.nocont + "/" + Settings.Settings.token);//+Settings.settings.token);
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaMateria = new List<models.ListaMateria>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("listmat").ToList();

                models.ListaMateria alumno;
                foreach (var al in arrJson)
                {
                    alumno = new models.ListaMateria();
                    alumno = JsonConvert.DeserializeObject<models.ListaMateria>(al.ToString());
                    Settings.Settings.nombre = alumno.nombre_mat;
                    Settings.Settings.especialidad = alumno.clave_mat;
                    Settings.Settings.horas = alumno.horas;
                    Settings.Settings.clave_grupo = alumno.clave_grupo;
                    //Settings.Settings.sexo = alumno.sexo;
                    //Settings.Settings.direccion = alumno.direccion;
                    //Settings.Settings.telefono = alumno.telefono;
                    listaMateria.Add(alumno);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }
            return listaMateria;
        }
        public async Task<Boolean> putAlumno(String telefono, String direccion, String email)
        {
            Boolean flag = false;
            List<Quejas> listSubjects = new List<Quejas>();
            try
            {

                wsAlumno wsStudent = new wsAlumno();
                //var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
                Alumno queja = new Alumno();
                queja.email = email;
                queja.telefono = telefono;
                queja.direccion = direccion;

                var json = JsonConvert.SerializeObject(queja);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                http.BaseAddress = new Uri("http://192.168.1.81:5000");
                // var authData = string.Format("{0}:{1}", "root", "root");
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                //var resp = await httpClient.GetAsync("SIIWS_PATM/api/wslista/getlista/" + Settings.idStudent + "/" + Settings.token);
                var resp = await httpClient.PutAsync("/sii/updalumno/" + Settings.Settings.nocont + "/" + Settings.Settings.token, content);//+Settings.settings.token);
                if (resp.IsSuccessStatusCode)
                    flag = true;

            }
            catch (Exception e)
            {

                e.ToString();
            }

            return flag;
        }
    }
}

