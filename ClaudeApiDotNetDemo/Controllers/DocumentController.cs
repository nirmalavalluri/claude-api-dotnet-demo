using ClaudeApiDotNetDemo.Models;
using ClaudeApiDotNetDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClaudeApiDotNetDemo.Controllers;

[ApiController]
[Route("api/document")]
public class DocumentController : ControllerBase
{
    private readonly IClaudeService _claudeService;

    public DocumentController(IClaudeService claudeService)
    {
        _claudeService = claudeService;
    }

    [HttpPost("summarize")]
    public async Task<IActionResult> Summarize(
        [FromBody] DocumentSummaryRequest request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.DocumentText))
        {
            return BadRequest("Document text is required.");
        }

        var prompt = $"""
        Summarize the following document in a clear and professional way.

        Include:
        - Main summary
        - Key points
        - Action items, if any

        Document:
        {request.DocumentText}
        """;

        var result = await _claudeService.GenerateResponseAsync(prompt, cancellationToken);

        return Ok(new
        {
            summary = result
        });
    }
}