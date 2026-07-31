// Middleware/ApiKeyMiddleware.cs
namespace AutoescolaReisSite.Crm.Middleware
{
    public class ApiKeyMiddleware
    {
        private const string HeaderName = "X-Api-Key";
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            // /health continua público, sem exigir API key
            if (context.Request.Path.StartsWithSegments("/health"))
            {
                await _next(context);
                return;
            }

            var apiKeyEsperada = configuration["Crm:ApiKey"];

            if (string.IsNullOrEmpty(apiKeyEsperada))
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("API key não configurada no servidor.");
                return;
            }

            if (!context.Request.Headers.TryGetValue(HeaderName, out var apiKeyRecebida) ||
                apiKeyRecebida != apiKeyEsperada)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API key inválida ou ausente.");
                return;
            }

            await _next(context);
        }
    }
}