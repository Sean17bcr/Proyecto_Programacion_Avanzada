using Newtonsoft.Json;
using Proyecto_Web.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace Proyecto_Web.Models
{
    public class UsuarioModel
    {
        private string urlWebApi = WebConfigurationManager.AppSettings["urlWebApi"];

        public UsuarioEnt IniciarSesion(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/IniciarSesion";
                JsonContent body = JsonContent.Create(entidad);

                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                }

                return null;
            }
        }
        public int Registrarse(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/Registrarse";
                JsonContent body = JsonContent.Create(entidad); //serializar

                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
        public List<UsuarioEnt> ConsultarUsuarios()
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarUsuarios";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
                }

                return new List<UsuarioEnt>();
            }
        }

        public UsuarioEnt ConsultarUsuario(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarUsuario?q=" + q;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                }

                return null;
            }
        }

        public List<RolEnt> ConsultarRoles()
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarRoles";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<RolEnt>>().Result;
                }

                return new List<RolEnt>();
            }
        }

        public List<MembresiaEnt> ConsultarMembresiasUsuario()
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarMembresiasUsuario";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<MembresiaEnt>>().Result;
                }

                return new List<MembresiaEnt>();
            }
        }

        public int EditarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/EditarUsuario";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
    }
}
