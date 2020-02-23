using Esepshi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Esepshi.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public HttpExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentException(nameof(next));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                    throw;

                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var res = JsonConvert.SerializeObject(new BaseResponse<string>
                {
                    Code = -2,
                    Data = ex.Message,
                    Message = "Внутрення ошибка. Необработанное исключение"
                },
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                await context.Response.WriteAsync(res);

                return;
            }
        }
    }
}
