
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;


namespace IO.Swagger.Tests
{
    public class CalculatorIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CalculatorIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Login_And_Addition_Works()
        {
            // שלב 1: קבלת JWT
            var loginResponse = await _client.PostAsync("/auth/login", null);
            loginResponse.EnsureSuccessStatusCode();

            var loginContent = await loginResponse.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(loginContent);
            var token = jsonDoc.RootElement.GetProperty("token").GetString();

            Assert.False(string.IsNullOrEmpty(token));

            // שלב 2: קריאה ל־/calculate עם Authorization Header
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var requestBody = new
            {
                num1 = 10,
                num2 = 5
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var request = new HttpRequestMessage(HttpMethod.Post, "/calculate");
            request.Headers.Add("operation", "add");
            request.Content = content;

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var resultJson = await response.Content.ReadAsStringAsync();
            var resultDoc = JsonDocument.Parse(resultJson);
            var result = resultDoc.RootElement.GetProperty("result").GetDouble();

            Assert.Equal(15, result);
        }
    }
}
