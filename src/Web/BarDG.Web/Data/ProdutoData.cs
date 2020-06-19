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
        private readonly AuthData _authData;

        public ProdutoData(IHttpClientFactory httpClientFactory, AuthData authData)
        {
            this._httpClient = httpClientFactory.CreateClient("Api");
            this._authData = authData;
        }

        public async Task<Produto[]> GetAllProdutos()
        {
            await _authData.ValidarToken(_httpClient);

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

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _authData.Token = null;
                return await GetAllProdutos();
            }

            return new Produto[] { };
        }
    }
}
