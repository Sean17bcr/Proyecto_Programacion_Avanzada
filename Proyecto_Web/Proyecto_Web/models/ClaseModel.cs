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
    public class ClaseModel
    {
        string urlWebApi = ConfigurationManager.AppSettings["urlWebApi"].ToString();

        public List<ClaseEnt> ConsultarClases()
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarClases";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<ClaseEnt>>().Result;
                }

                return new List<ClaseEnt>();
            }
        }

        public ClaseEnt ConsultarClase(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarClase?q=" + q;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<ClaseEnt>().Result;
                }

                return null;
            }
        }

        public long RegistrarClase(ClaseEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/RegistrarClase";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<long>().Result;
                }

                return 0;
            }
        }

        public int ActualizarClase(ClaseEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ActualizarClase";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
        public int EliminarClase(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/EliminarClase?q=" + q;
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
