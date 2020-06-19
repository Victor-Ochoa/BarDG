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

        public NotaFiscalData(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient("Api");
        }


        public async Task<NotaFiscal[]> GetAllNotaFiscal()
        {
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

            return new NotaFiscal[] { };
        }

        public async Task<NotaFiscal> GetNotaFiscal(int notaFiscalId)
        {
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

            return new NotaFiscal { };
        }

    }
}
