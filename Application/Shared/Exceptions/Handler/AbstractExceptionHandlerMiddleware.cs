using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Application.Shared.Exceptions.Handler;

public abstract class AbstractExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    
    public abstract (HttpStatusCode code, Dictionary<string, string> errors) GetResponse(Exception exception);

    public AbstractExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var (status, errors) = GetResponse(exception);

            var errorResponse = new ErrorResponse(
                status: (int)status,
                path: context.Request.Path,
                errors: errors
            );

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)status;
            
            var jsonResponse = JsonSerializer.Serialize(errorResponse);

            await response.WriteAsync(jsonResponse);
        }
    }
}