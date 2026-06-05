# Claude API Integration with ASP.NET Core Web API

A practical ASP.NET Core Web API demo showing how to integrate Anthropic Claude API for document summarization and AI-assisted support reply drafting.

This project is created as a simple, practical reference for .NET developers who want to understand how an AI API can be integrated into an ASP.NET Core Web API application.

## Features

* ASP.NET Core Web API
* Claude API integration using `HttpClient`
* Swagger/OpenAPI support for testing
* Document summarization endpoint
* AI-assisted support reply drafting endpoint
* Clean service-based project structure
* Configuration-based Claude API setup

## API Endpoints

### Document Summarization

```http
POST /api/document/summarize
```

Sample request:

```json
{
  "documentText": "This project demonstrates how to integrate Claude API with an ASP.NET Core Web API."
}
```

### Support Reply Drafting

```http
POST /api/support/draft-reply
```

Sample request:

```json
{
  "customerMessage": "I uploaded my document but I am not able to see the summary. Can you help?",
  "tone": "professional"
}
```

## Configuration

Add your Claude API key locally in `appsettings.json` for testing:

```json
"Claude": {
  "ApiKey": "YOUR_ANTHROPIC_API_KEY",
  "BaseUrl": "https://api.anthropic.com",
  "Model": "claude-sonnet-4-5-20250929",
  "MaxTokens": 1024
}
```

Important: Do not commit real API keys to GitHub. Keep the `ApiKey` value blank before pushing code to a public repository.

## How to Run

1. Clone the repository.

```bash
git clone https://github.com/nirmalavalluri/claude-api-dotnet-demo.git
```

2. Open the project in Visual Studio.

3. Add your Claude API key locally in `appsettings.json`.

4. Run the project.

5. Open Swagger UI:

```text
https://localhost:YOUR_PORT/swagger
```

6. Test the available endpoints.

## Related Article

This GitHub demo supports the technical article:

**How to Use Claude API in a .NET Application**

https://ainexarch.com/how-to-use-claude-api-in-a-dotnet-application/

## Notes

This is a learning-focused demo project. It shows the basic integration pattern between ASP.NET Core Web API and Claude API.

For production applications, consider adding:

* Secure secret management
* Retry policies
* Structured logging
* Exception middleware
* Unit tests
* Request validation
* Rate limiting
* CI/CD pipeline

## Technologies Used

* .NET
* ASP.NET Core Web API
* C#
* Claude API
* Anthropic
* Swagger/OpenAPI
* HttpClient
