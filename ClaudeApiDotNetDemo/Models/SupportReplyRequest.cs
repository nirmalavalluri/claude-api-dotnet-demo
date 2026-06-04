namespace ClaudeApiDotNetDemo.Models;

public class SupportReplyRequest
{
    public string CustomerMessage { get; set; } = string.Empty;
    public string Tone { get; set; } = "professional";
}