namespace ClaudeApiDotNetDemo.Services;

public interface IClaudeService
{
    Task<string> GenerateResponseAsync(string prompt, CancellationToken cancellationToken);
}