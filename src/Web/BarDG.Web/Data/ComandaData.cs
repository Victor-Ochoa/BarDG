using BarDG.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BarDG.Web.Data
{
    public class ComandaData
    {

        private readonly HttpClient _httpClient;

        public ComandaData(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient("Api");
        }
        public async Task<Comanda[]> GetAllComanda()
        {
            var response = await _httpClient.GetAsync("/api/Comanda");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Comanda[]>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

            }

            return new Comanda[] { };
        }
        public async Task<int> NewComanda()
        {
            var response = await _httpClient.PutAsync("/api/Comanda/Create",new StringContent(""));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var comanda = JsonSerializer.Deserialize<Comanda>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

                return comanda.Id;

            }

            return 0;
        }
    }
}
