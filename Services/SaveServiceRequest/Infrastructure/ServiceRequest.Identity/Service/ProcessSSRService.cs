using Common.Application.Model;
using Common.Enums;
using Loggers.Logs;
using Loggers.Logs.Model;
using ServiceRequest.Application.Contracts.Identity;
using ServiceRequest.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Common;
using Utility.Extensions;

namespace ServiceRequest.Identity.Service
{
    public class ProcessSSRService : IProcessSSRService
    {
        private readonly ILoggerService _loggerService;
        public ProcessSSRService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task<OutResponse> SaveServiceAsync(SaveServiceRequest saveServiceRequest)
        {
            var outresponse = new OutResponse();
            if (saveServiceRequest is null)
            {
                outresponse.ResponseMessage = "";
                return outresponse;
            }
            else
            {
                if(saveServiceRequest.IsEncrypt)
                {
                    var decryptData = saveServiceRequest?.RequestData?.ToDecryptOpenSSL(saveServiceRequest.SessionId);
                    saveServiceRequest.RequestData = decryptData;
                }

                await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = saveServiceRequest.ServiceID, MethodId = saveServiceRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = saveServiceRequest.RequestId, CorelationSession = saveServiceRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Process Identity Service" });
                await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = saveServiceRequest.RequestId, TokenID = saveServiceRequest.TokenId, TellerID = saveServiceRequest.TellerId, UserID = saveServiceRequest.ReturnId(), SessionID = saveServiceRequest.SessionId, MethodId = saveServiceRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {saveServiceRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

                switch(saveServiceRequest.MethodId)
                {
                    case 1: //Pan Validation Check 
                        PanValidation
                        break;
                }
            }

            return outresponse;
        }
    }
}
