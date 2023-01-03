using BulletJournal.Models.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BulletJournal.Web.Services.Interfaces
{
    public abstract class BaseService
    {
        protected readonly HttpClient HttpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            HttpClient = httpClientFactory.CreateClient(Constants.MAIN_HTTP_CLIENT_NAME);
            _httpContextAccessor = httpContextAccessor;
        }

        protected virtual async Task<TOutput> PostToEndpoint<TInput, TOutput>(string url, TInput input)
        {
            await RefreshToken();

            var serializedObject = JsonConvert.SerializeObject(input);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var output = JsonConvert.DeserializeObject<TOutput>(responseContent);
            return output;
        }

        protected virtual async Task<HttpResponseMessage> PostToEndpoint<TInput>(string url, TInput input)
        {
            await RefreshToken();

            var serializedObject = JsonConvert.SerializeObject(input);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            return response;

        }

        protected virtual async Task<TOutput> PostToEndpoint<TOutput>(string url)
        {
            await RefreshToken();

            var response = await HttpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var output = JsonConvert.DeserializeObject<TOutput>(responseContent);
            return output;
        }


        protected virtual async Task<HttpResponseMessage> DeleteOnEndpoint(string url)
        {
            await RefreshToken();

            var response = await HttpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            return response;
        }


        protected virtual async Task<TOutput> GetFromEndpoint<TOutput>(string url)
        {
            await RefreshToken();

            var response = await HttpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<TOutput>(content);

            return output;
        }

        private async Task RefreshToken()
        {
            var strTokenObj = _httpContextAccessor.HttpContext.Session.GetString("access_token");

            //Get token from session
            var token = string.IsNullOrWhiteSpace(strTokenObj) ? await Authenticate() : JsonConvert.DeserializeObject<JwtToken>(strTokenObj);
            if (token == null || string.IsNullOrWhiteSpace(token.AccessToken) || token.ExpiresAt <= DateTime.UtcNow)
                token = await Authenticate();

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        }


        protected virtual async Task<JwtToken> Authenticate()
        {
            var response = await HttpClient.PostAsJsonAsync("auth", new Credential { UserName = "admin", Password = "password" });
            response.EnsureSuccessStatusCode();
            var strJwt = await response.Content.ReadAsStringAsync();
            _httpContextAccessor.HttpContext.Session.SetString("access_token", strJwt);

            return JsonConvert.DeserializeObject<JwtToken>(strJwt);
        }
    }
}
