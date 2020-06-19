using BarDG.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BarDG.Web.Data
{
    public class AuthData
    {
        private readonly CredenciaisAuth _credenciaisAuth;
        private readonly HttpClient _httpClient;

        public string Token;

        public AuthData(CredenciaisAuth credenciaisAuth, IHttpClientFactory httpClientFactory)
        {
            this._credenciaisAuth = credenciaisAuth;
            this._httpClient = httpClientFactory.CreateClient("Api");
        }

        public async Task<string> GenerateToken()
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", _credenciaisAuth);

            _httpClient.DefaultRequestHeaders.Remove("Authorization");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return string.Empty;
        }


        public async Task ValidarToken(HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(Token))
                Token = await GenerateToken();

            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
        }
    }
}
