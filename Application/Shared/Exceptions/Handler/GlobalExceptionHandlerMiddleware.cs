using System.Net;
using Application.Shared.Exceptions.Exceptions;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Application.Shared.Exceptions.Handler;

public class GlobalExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
{
    public GlobalExceptionHandlerMiddleware(RequestDelegate next) : base(next)
    {
    }
    
    public override (HttpStatusCode code, Dictionary<string, string> errors) GetResponse(Exception exception)
    {
        HttpStatusCode code;
        var errors = new Dictionary<string, string> {{ "Error", exception.Message }};
        switch (exception)
        {
            case EntityHasChildrenException
                or EntityCannotBeDeletedException
                or EntityAlreadyAssignedException
                or EntityAlreadyExistsException
                or RequestCannotBePerformedException:
                    code = HttpStatusCode.Conflict;
                    break;
            
            case EntityDoesNotExistsException:
                    code = HttpStatusCode.NotFound;
                    break;
            
            case AutoMapperMappingException autoMapperMappingException:
                code = HttpStatusCode.BadRequest;
                if (autoMapperMappingException.InnerException is ValidationInDomainException validationInDomainException)
                {
                    errors = new Dictionary<string, string> { { "Error", validationInDomainException.Message } };
                    break;
                }
                errors = new Dictionary<string, string> { { "Error", autoMapperMappingException.Message } };
                break;
                
            default:
                code = HttpStatusCode.InternalServerError;
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.Source);
                Console.WriteLine("-_____________________________________________________________-");
                Console.WriteLine(exception.InnerException?.Message);
                Console.WriteLine(exception.InnerException?.StackTrace);
                Console.WriteLine("-_____________________________________________________________-");
                Console.WriteLine(exception.InnerException?.InnerException?.Message);
                Console.WriteLine(exception.InnerException?.InnerException?.StackTrace);
                break;
        }
        return (code, errors);
    }
}