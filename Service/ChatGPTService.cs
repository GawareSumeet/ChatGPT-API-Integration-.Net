using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;
namespace AutomatedResponseSystem.Service
{
    public class ChatGPTService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ChatGPTService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<string> GetResponseAsync(string userMessage)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            var jsonContent = JsonSerializer.Serialize(new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = userMessage }
            }
            });
            request.Content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
