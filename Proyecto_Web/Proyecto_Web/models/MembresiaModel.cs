using System;
using System.Collections.Generic;
using Proyecto_Web.Entities;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Proyecto_Web.Models
{
    public class MembresiaModel
    {

        string urlWebApi = ConfigurationManager.AppSettings["urlWebApi"].ToString();

        public List<MembresiaEnt> ConsultarMembresias()
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarMembresias";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<MembresiaEnt>>().Result;
                }

                return new List<MembresiaEnt>();
            }
        }
        public MembresiaEnt ConsultarMembresia(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarMembresia?q=" + q;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<MembresiaEnt>().Result;
                }

                return null;
            }
        }

        public long RegistrarMembresia(MembresiaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/RegistrarMembresia";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<long>().Result;
                }

                return 0;
            }
        }

        public int ActualizarMembresia(MembresiaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ActualizarMembresia";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
        public int EliminarMembresia(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/EliminarMembresia?q=" + q;
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