using System.Net;
using System.Text.Json;

namespace ProductService.API.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Unhandled Exception | Method: {Method} | Path: {Path} | Message: {Message}",
                context.Request.Method,
                context.Request.Path,
                ex.Message);

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, errorType) = ex switch
        {
            ArgumentNullException => (HttpStatusCode.BadRequest, "Argument Null"),
            ArgumentException => (HttpStatusCode.BadRequest, "Bad Argument"),
            KeyNotFoundException => (HttpStatusCode.NotFound, "Not Found"),
            UnauthorizedAccessException => (HttpStatusCode.Unauthorized, "Unauthorized"),
            InvalidOperationException => (HttpStatusCode.BadRequest, "Invalid Operation"),
            NotImplementedException => (HttpStatusCode.NotImplemented, "Not Implemented"),
            TimeoutException => (HttpStatusCode.GatewayTimeout, "Timeout"),
            _ => (HttpStatusCode.InternalServerError, "Internal Server Error")
        };

        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            success = false,
            statusCode = (int)statusCode,
            errorType,
            message = ex.Message,
            detail = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                ? ex.StackTrace
                : null,
            timestamp = DateTime.UtcNow,
            path = context.Request.Path.Value
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
    }
}