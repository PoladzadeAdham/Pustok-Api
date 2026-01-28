using Pustok.Buisness.Abstractions;
using Pustok.Buisness.Dtos;

namespace Pustok.Presentation.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ResultDto resultDto = new ResultDto()
                {
                    IsSucced = false,
                    StatusCode = 500,
                    Message = ex.Message,
                };

                if(ex is IBaseException baseException)
                {
                    resultDto.StatusCode = baseException.StatusCode;
                    resultDto.Message = ex.Message;
                }

                context.Response.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = resultDto.StatusCode; 

                await context.Response.WriteAsJsonAsync(resultDto);
                
            }

        }

    }
}
