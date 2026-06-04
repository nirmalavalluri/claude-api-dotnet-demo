using ClaudeApiDotNetDemo.Models;
using ClaudeApiDotNetDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClaudeApiDotNetDemo.Controllers;

[ApiController]
[Route("api/support")]
public class SupportController : ControllerBase
{
    private readonly IClaudeService _claudeService;

    public SupportController(IClaudeService claudeService)
    {
        _claudeService = claudeService;
    }

    [HttpPost("draft-reply")]
    public async Task<IActionResult> DraftReply(
        [FromBody] SupportReplyRequest request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.CustomerMessage))
        {
            return BadRequest("Customer message is required.");
        }

        var prompt = $"""
        Draft a {request.Tone} customer support reply for the following customer message.

        Requirements:
        - Be helpful
        - Be concise
        - Be professional
        - Do not overpromise

        Customer message:
        {request.CustomerMessage}
        """;

        var result = await _claudeService.GenerateResponseAsync(prompt, cancellationToken);

        return Ok(new
        {
            reply = result
        });
    }
}