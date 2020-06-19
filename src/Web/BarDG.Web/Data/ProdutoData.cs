using BarDG.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BarDG.Web.Data
{
    public class ProdutoData
    {
        private readonly HttpClient _httpClient;

        public ProdutoData(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient("Api");
        }

        public async Task<Produto[]> GetAllProdutos()
        {
            var response = await _httpClient.GetAsync("/api/Produto");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Produto[]>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

            }

            return new Produto[] { };
        }
    }
}
