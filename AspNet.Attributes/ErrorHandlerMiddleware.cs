using Application.Behaviours;
using Common.Application.Model;
using Common.Enums;
using Common.Wrappers;
using Loggers.Logs;
using Loggers.Logs.Model;
using Microsoft.AspNetCore.Http;
using Shared.Services.ESBMessageService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utility.Extensions;

namespace AspNet.Attributes
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILoggerService _loggerService;

        private readonly EsbMessageService _esbMessageService;

        public ErrorHandlerMiddleware(RequestDelegate next, EsbMessageService esbMessageService, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
            _esbMessageService = esbMessageService;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestContent = string.Empty;

            try
            {
                var request = context.Request;
                request.EnableBuffering();
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer);
                requestContent = Encoding.UTF8.GetString(buffer);
                request.Body.Position = 0;  //rewinding the stream to 0
                await _next(context);

            }
            catch (Exception error)
            {

                #region Write DB Log
                var exceptionDetails = new Exceptions();
                try
                {
                    exceptionDetails = error.GetExceptionDetails();
                }
                catch (Exception ex)
                {

                }

                try
                {
                    var requestData = requestContent.ToJsonDeSerialize<InRequest>();
                    await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = requestData.RequestId, TokenID = requestData.TokenId, TellerID = requestData.TellerId, UserID = requestData.ReturnId(), SessionID = requestData.SessionId, MethodId = requestData.MethodId, Module = "", Message = $"Exception :  FileName = {exceptionDetails.FileName} , LineNumber = {exceptionDetails.LineNumber} , Exception = {error?.GetExceptionMessage()} ,RequestData = {requestData.RequestData}  ", PriorityId = LogPriority.Exception.GetIntValue(), ChannelID = requestData.ChannelID });
                }
                catch (Exception ex)
                {

                }

                #endregion

                #region Prepare OutResponse
                var esbMessages = new EsbMessages();
                try
                {
                    esbMessages = await _esbMessageService.GetCorrectMessage("contract error");
                }
                catch (Exception ex)
                {


                }
                #endregion

                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                var responseModelview = new OutResponse { ResponseMessage = esbMessages.CorrectedMessage, ResponseMessage_Hindi = esbMessages.HindiMessage, MessageType = MessageType.Exclam.GetStringValue(), ResponseCode = ResponseCode.Failure.GetIntValue() };

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
                                    responseModelview.ResponseMessage = "You are Not Authorized";
                                    break;
                                default:
                                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                    responseModel.Errors = new List<string> { errorres.Message };
                                    break;
                            }
                        }
                        catch (Exception)
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
                        break;
                }

                var result = responseModelview.ToJsonSerialize();
                await response.WriteAsync(result);
            }
        }

    }
}
