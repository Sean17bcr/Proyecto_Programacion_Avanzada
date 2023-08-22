
using Newtonsoft.Json;
using Proyecto_Web.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Configuration;

namespace Proyecto_Web.Models
{
    public class InscripcionModel
    {
        private string urlWebApi = WebConfigurationManager.AppSettings["urlWebApi"];

        public List<InscripcionEnt> VerInscripciones()
        {
            using (var client = new HttpClient())
            {
                string urlWebApi = "https://localhost:44332/";

                client.BaseAddress = new Uri(urlWebApi);

                string url = "api/VerInscripciones";

                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    string json = resp.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<InscripcionEnt>>(json);
                }

                return new List<InscripcionEnt>();
            }
        }

        public int AgregarInscripcion(InscripcionEnt inscripcion)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/AgregarInscripcion";
                string json = JsonConvert.SerializeObject(inscripcion);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = client.PostAsync(url, content).Result;

                if (resp.IsSuccessStatusCode)
                {
                    string result = resp.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(result);
                }

                return 0;
            }
        }

        public int EditarInscripcion(InscripcionEnt inscripcion)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + $"api/EditarInscripcion/{inscripcion.Inscripcion_id}";
                string json = JsonConvert.SerializeObject(inscripcion);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = client.PutAsync(url, content).Result;

                if (resp.IsSuccessStatusCode)
                {
                    string result = resp.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(result);
                }

                return 0;
            }
        }

        public InscripcionEnt ConsultarInscripcion(long id)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + $"api/ConsultarInscripcion/{id}";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    string json = resp.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<InscripcionEnt>(json);
                }

                return null;
            }
        }

        public int EliminarInscripcion(long id)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + $"api/EliminarInscripcion/{id}";
                HttpResponseMessage resp = client.DeleteAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    string result = resp.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(result);
                }

                return 0;
            }
        }
    }
}

