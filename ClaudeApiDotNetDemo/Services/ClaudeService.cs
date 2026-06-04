using System.Text;
using System.Text.Json;
using ClaudeApiDotNetDemo.Configuration;
using Microsoft.Extensions.Options;

namespace ClaudeApiDotNetDemo.Services;

public class ClaudeService : IClaudeService
{
    private readonly HttpClient _httpClient;
    private readonly ClaudeOptions _options;

    public ClaudeService(HttpClient httpClient, IOptions<ClaudeOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<string> GenerateResponseAsync(string prompt, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_options.ApiKey))
        {
            throw new InvalidOperationException("Claude API key is missing.");
        }

        var requestBody = new
        {
            model = _options.Model,
            max_tokens = _options.MaxTokens,
            messages = new[]
            {
                new
                {
                    role = "user",
                    content = prompt
                }
            }
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "/v1/messages");

        request.Headers.Add("x-api-key", _options.ApiKey);
        request.Headers.Add("anthropic-version", "2023-06-01");

        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");

        using var response = await _httpClient.SendAsync(request, cancellationToken);

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException(
                $"Claude API request failed. Status: {response.StatusCode}. Response: {responseContent}");
        }

        using var jsonDocument = JsonDocument.Parse(responseContent);

        var content = jsonDocument.RootElement.GetProperty("content");

        if (content.GetArrayLength() == 0)
        {
            return string.Empty;
        }

        return content[0].GetProperty("text").GetString() ?? string.Empty;
    }
}