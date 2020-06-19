using BarDG.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BarDG.Web.Data
{
    public class NotaFiscalData
    {
        private readonly HttpClient _httpClient;
        private readonly AuthData _authData;

        public NotaFiscalData(IHttpClientFactory httpClientFactory, AuthData authData)
        {
            this._httpClient = httpClientFactory.CreateClient("Api");
            this._authData = authData;
        }


        public async Task<NotaFiscal[]> GetAllNotaFiscal()
        {
            await _authData.ValidarToken(_httpClient);

            var response = await _httpClient.GetAsync("/api/NotaFiscal");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<NotaFiscal[]>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _authData.Token = null;
                return await GetAllNotaFiscal();
            }
            return new NotaFiscal[] { };
        }

        public async Task<NotaFiscal> GetNotaFiscal(int notaFiscalId)
        {
            await _authData.ValidarToken(_httpClient);

            var response = await _httpClient.GetAsync($"/api/NotaFiscal/{notaFiscalId}");

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
                return await GetNotaFiscal(notaFiscalId);
            }

            return new NotaFiscal { };
        }

    }
}
