using LibraryProject.Domain.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace LibraryProject.Application.Middlware
{
    public class ExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
    {
        public ExceptionHandlerMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            HttpStatusCode code;
            switch (exception)
            {
                case KeyNotFoundException
                    or NoSuchUserException
                    or FileNotFoundException
                    or EntityNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case EntityAlreadyExistsException:
                    code = HttpStatusCode.Conflict;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ArgumentException
                    or InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            return (code, JsonConvert.SerializeObject(new SimpleResponse(exception.Message)));
        }
    }
}
