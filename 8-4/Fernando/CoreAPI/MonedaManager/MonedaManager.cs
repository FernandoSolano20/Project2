using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using Newtonsoft.Json;

namespace CoreAPI.MonedaManager
{
    public class MonedaManager
    {
        private static Moneda _monedas;
        private static string dia;
        private string _urlApiMoneda;

        public MonedaManager()
        {
            _urlApiMoneda = ConfigurationManager.AppSettings["URL_API_MONEDA"];
            var diaDeHoy = DateTime.Now.ToString("yyyy-MM-dd");
            _urlApiMoneda = string.Format(_urlApiMoneda, diaDeHoy);
            LoadMoneda(diaDeHoy);
        }

        private void LoadMoneda(string diaDeHoy)
        {
            if (_monedas == null || !string.Equals(dia, diaDeHoy))
            {
                dia = diaDeHoy;
                var client = new HttpClient { BaseAddress = new Uri(_urlApiMoneda) };
                var responseMessage = client.GetAsync(_urlApiMoneda, HttpCompletionOption.ResponseContentRead);
                var resultAsync = responseMessage.GetAwaiter().GetResult().Content.ReadAsStringAsync();
                var rate = JsonConvert.DeserializeObject<Rate>(resultAsync.GetAwaiter().GetResult());
                _monedas = rate?.rates;
            }
        }

        public IList<string> ObtenerMonedaPaises()
        {
            var monedas = new List<string>();

            foreach (var prop in _monedas.GetType().GetProperties())
            {
                monedas.Add(prop.Name);
            }

            return monedas;
        }

        public Moneda ObtenerMonedaValor()
        {
            return _monedas;
        }
    }
}
