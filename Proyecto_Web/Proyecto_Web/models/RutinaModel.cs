using Newtonsoft.Json;
using Proyecto_Web.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Proyecto_Web.Models
{
    public class RutinaModel
    {
        string urlWebApi = ConfigurationManager.AppSettings["urlWebApi"].ToString();

        public List<RutinaEnt> ConsultarRutinas()
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarRutinas";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<RutinaEnt>>().Result;
                }

                return new List<RutinaEnt>();
            }
        }

        public RutinaEnt ConsultarRutina(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarRutina?q=" + q;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<RutinaEnt>().Result;
                }

                return null;
            }
        }
        public long RegistrarRutina(RutinaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/RegistrarRutina";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<long>().Result;
                }

                return 0;
            }
        }

        public int ActualizarRutina(RutinaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ActualizarRutina";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
        public int EliminarRutina(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/EliminarRutina?q=" + q;
                HttpResponseMessage resp = client.DeleteAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
    }
}