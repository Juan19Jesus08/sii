using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using sii.models;

namespace sii.ws
{
    class wsLogin
    {

        public async Task<List<String>> Conexion(String user, String pwd)
        {
            HttpClient httpClient = new HttpClient();
            //192.168.100.56:5000
            httpClient.BaseAddress = new Uri("http://192.168.1.81:5000");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var authData = string.Format("{0}:{1}", "root", "root");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            
            var respuesta = await httpClient.GetAsync("/sii/login/" + user + "/" + pwd);
            var objJSON = respuesta.Content.ReadAsStringAsync().Result;

            //Login objLogin = new Login();
            Login objLogin = new Login();

            if (objJSON != null)
            {
                objLogin = JsonConvert.DeserializeObject<Login>(objJSON);
            }
            List<String> list = new List<string>();
            //list.Add(objLogin.nocont);
            //list.Add(objLogin.token);
            Settings.Settings.token = objLogin.token;
           
            return list;
        }
    }
}
