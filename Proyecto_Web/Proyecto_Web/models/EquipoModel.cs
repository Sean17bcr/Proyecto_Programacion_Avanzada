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
    public class EquipoModel
    {
        string urlWebApi = ConfigurationManager.AppSettings["urlWebApi"].ToString();

        public List<EquipoEnt> ConsultarEquipos()
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarEquipos";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<EquipoEnt>>().Result;
                }

                return new List<EquipoEnt>();
            }
        }

        public EquipoEnt ConsultarEquipo(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarEquipo?q=" + q;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<EquipoEnt>().Result;
                }

                return null;
            }
        }

        public long RegistrarEquipo(EquipoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/RegistrarEquipo";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<long>().Result;
                }

                return 0;
            }
        }

        public int ActualizarEquipo(EquipoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ActualizarEquipo";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
        public int EliminarEquipo(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/EliminarEquipo?q=" + q;
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
