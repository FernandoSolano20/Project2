using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using Newtonsoft.Json;

namespace CoreAPI.LocalizacionManager
{
    public class LocalizacionManager
    {
        private static IList<Provincia> Provincias = new List<Provincia>();
        private static IList<Pais> Paises = new List<Pais>();
        private string _urlApiProvincias;
        private string _urlApiPaises;

        public LocalizacionManager()
        {
            _urlApiProvincias = ConfigurationManager.AppSettings["URL_API_PROVINCIAS"];
            _urlApiPaises = ConfigurationManager.AppSettings["URL_API_PAISES"];
        }

        private void LoadPaises()
        {
            if (Paises.Count == 0)
            {
                var client = new HttpClient { BaseAddress = new Uri(_urlApiPaises) };
                var responseMessage = client.GetAsync(_urlApiPaises, HttpCompletionOption.ResponseContentRead);
                var resultAsync = responseMessage.GetAwaiter().GetResult().Content.ReadAsStringAsync();
                Paises = JsonConvert.DeserializeObject<List<Pais>>(resultAsync.GetAwaiter().GetResult());
            }
        }

        private void LoadProvincias()
        {
            if (Provincias.Count == 0)
            {
                var client = new HttpClient { BaseAddress = new Uri(_urlApiProvincias) };
                var responseMessage = client.GetAsync(_urlApiProvincias, HttpCompletionOption.ResponseContentRead);
                var resultAsync = responseMessage.GetAwaiter().GetResult().Content.ReadAsStringAsync();
                var pais = JsonConvert.DeserializeObject<Pais>(resultAsync.GetAwaiter().GetResult());
                Provincias = pais?.Provincias;
            }
        }

        public IList<string> ObtenerPaises()
        {
            LoadPaises();
            var paises = new List<string>();

            foreach (var pais in Paises)
            {
                paises.Add(pais.Name);
            }

            return paises;
        }

        public IList<string> ObtenerProvincias()
        {
            LoadProvincias();
            var provincias = new List<string>();

            foreach (var provincia in Provincias)
            {
                provincias.Add(provincia.Title);
            }

            return provincias;
        }

        public IList<string> ObtenerCantonesPorProvincia(string provincia)
        {
            LoadProvincias();
            var cantones = new List<string>();

            foreach (var prov in Provincias)
            {
                if (prov.Title == provincia)
                {
                    foreach (var canton in prov.Cantones)
                    {
                        cantones.Add(canton.Title);
                    }
                    break;
                }
            }

            return cantones;
        }

        public IList<string> ObtenerDistritoPorCanton(string provincia, string canton)
        {
            LoadProvincias();
            var distritos = new List<string>();

            foreach (var prov in Provincias)
            {
                if (prov.Title == provincia)
                {
                    foreach (var c in prov.Cantones)
                    {
                        if (c.Title == canton)
                        {
                            foreach (var distrito in c.Distritos)
                            {
                                distritos.Add(distrito.Title);
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            return distritos;
        }
    }
}
