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
        private readonly AuthData _authData;

        public ComandaData(IHttpClientFactory httpClientFactory, AuthData authData)
        {
            this._httpClient = httpClientFactory.CreateClient("Api");
            this._authData = authData;
        }

        public async Task<Comanda[]> GetAllComanda()
        {
            await _authData.ValidarToken(_httpClient);

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

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _authData.Token = null;
                return await GetAllComanda();
            }


            return new Comanda[] { };
        }
        public async Task<Comanda> GetComanda(int comandaId)
        {
            await _authData.ValidarToken(_httpClient);

            var response = await _httpClient.GetAsync($"/api/Comanda/{comandaId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Comanda>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _authData.Token = null;
                return await GetComanda(comandaId);
            }

            return new Comanda{ };
        }
        public async Task<int> NewComanda()
        {
            await _authData.ValidarToken(_httpClient);

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

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _authData.Token = null;
                return await NewComanda();
            }

            return 0;
        }
        public async Task<Comanda> AddProduto(int comandaId, int produtoId)
        {
            await _authData.ValidarToken(_httpClient);

            var response = await _httpClient.PostAsJsonAsync("/api/Comanda/AddItemToComanda", new Domain.Command.AddItemToComanda() { ComandaId = comandaId, ProductId = produtoId});

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Comanda>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _authData.Token = null;
                return await AddProduto(comandaId, produtoId);
            }

            return new Comanda { };
        }
        public async Task<Comanda> ResetComanda(int comandaId)
        {
            await _authData.ValidarToken(_httpClient);

            var response = await _httpClient.PostAsJsonAsync("/api/Comanda/ResetComanda", new Domain.Command.ResetComanda() { ComandaId = comandaId });

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Comanda>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _authData.Token = null;
                return await ResetComanda(comandaId);
            }

            return new Comanda { };
        }
        public async Task<NotaFiscal> FacharComanda(int comandaId)
        {
            await _authData.ValidarToken(_httpClient);

            var response = await _httpClient.PostAsJsonAsync("/api/NotaFiscal/Generate", new Domain.Command.GenerateNotaFiscal() { ComandaId = comandaId });

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<NotaFiscal>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _authData.Token = null;
                return await FacharComanda(comandaId);
            }

            return new NotaFiscal { };
        }
    }
}
