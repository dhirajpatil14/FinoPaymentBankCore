using Application.Behaviours;
using Common.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Utility.Extensions;

namespace AspNet.Attributes
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        try
                        {
                            var errorres = ((HttpRequestException)error);

                            switch (errorres.StatusCode)
                            {
                                case HttpStatusCode.Unauthorized:
                                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                    responseModel.Errors = new List<string> { "You are not Authorized" };
                                    break;
                                default:
                                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                    responseModel.Errors = new List<string> { errorres.Message };
                                    break;
                            }
                        }
                        catch
                        {

                        }


                        break;
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        //try
                        //{
                        //    var errorres = ((HttpResponseException)error)?.Response;

                        //    switch (errorres.StatusCode)
                        //    {
                        //        case HttpStatusCode.Unauthorized:
                        //            response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        //            responseModel.Errors = new List<string> { "You are not Authorized" };
                        //            break;
                        //        default:
                        //            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        //            break;
                        //    }
                        //}
                        //catch
                        //{
                        //    var errorres = ((HttpRequestException)error);

                        //    switch (errorres.StatusCode)
                        //    {
                        //        case HttpStatusCode.Unauthorized:
                        //            response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        //            responseModel.Errors = new List<string> { "You are not Authorized" };
                        //            break;
                        //        default:
                        //            response.StatusCode = (int)errorres.StatusCode;
                        //            responseModel.Errors = new List<string> { errorres.Message };
                        //            break;
                        //    }
                        //}

                        break;
                }

                var result = responseModel.ToJsonSerialize();
                await response.WriteAsync(result);
            }
        }

    }
}
