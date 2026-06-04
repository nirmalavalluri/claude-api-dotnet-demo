namespace ClaudeApiDotNetDemo.Configuration;

public class ClaudeOptions
{
    public string ApiKey { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = "https://api.anthropic.com";
    public string Model { get; set; } = string.Empty;
    public int MaxTokens { get; set; } = 1024;
}