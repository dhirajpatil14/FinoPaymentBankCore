using Common.Application.Interface;
using Common.Application.Model;
using Common.Application.Model.XML;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Utility.Extensions.Aadhar
{
    public static class AadharExtension
    {
        /// <summary>
        /// For Authentication
        /// </summary>
        public static async Task<string> GetAadharXmlAsync(this Aadhaar aadhaar, IEkycAuaService ekycAuaService)
        {
            var decodeXML = aadhaar?.RequestData?.PidData?.Value.ToBase64Decode();
            var uidResponse = decodeXML.ToParseOtpRd();
            var KycAur = await ekycAuaService.GetKycAadhar();
            var authXml = new AuthXmlCreationLevelAuaRd
            {
                AUA_Key = KycAur.AuaKey,
                Auth_UID = aadhaar?.Uid,
                Auth_TID = KycAur.AuthTid,
                Auth_VC = KycAur.AuaSa,
                Auth_txn = AuthTxn(),
                Auth_RC = KycAur.AuthRc,
                Uses_pi = KycAur.UsesPi,
                Uses_pa = KycAur.UsesPa,
                Uses_pfa = KycAur.UsesPfa,
                Uses_bio = KycAur.UsesBio,
                Uses_bt = aadhaar.AuthType is null ? "FMR" : aadhaar.AuthType is not null && uidResponse.ISFIR is not null ? uidResponse.ISFIR is "1" ? "FIR" : KycAur.UsesBt : aadhaar.AuthType is not null && aadhaar.AuthType is "FIR" ? "FIR" : KycAur.UsesBt,
                Uses_pin = KycAur.UsesPin,
                Uses_otp = KycAur.UsesOtp,
                Meta_udc = KycAur.MetaUdc,
                Meta_rdsId = uidResponse.rdsId,
                Meta_rdsVer = uidResponse.rdsVer,
                Meta_dpId = uidResponse.dpId,
                Meta_dc = uidResponse.dc,
                Meta_mi = uidResponse.mi,
                Meta_mc = uidResponse.mc,
                Skey_ci = uidResponse.ci,
                Auth_Skey_value = uidResponse.Skey,
                Data_type = uidResponse.type,
                Data_PID = uidResponse.PID,
                Auth_Hmac = uidResponse.Hmac,
                RFU1 = KycAur.Rfu1,
                RFU2 = KycAur.Rfu2,
                User_Id = aadhaar.UiRefNumber is not null ? aadhaar?.UserId : string.Empty,
                HW_SerNum = aadhaar.UiRefNumber is not null ? aadhaar?.HWSerNum : string.Empty,
                SourceType_AppId = aadhaar.UiRefNumber is not null ? aadhaar?.SourceTypeAppId : string.Empty,
                Branch_Code = aadhaar.UiRefNumber is not null ? aadhaar?.BranchCode : string.Empty,
                Latitude = aadhaar.UiRefNumber is not null ? aadhaar?.Latitude : string.Empty,
                Longitude = aadhaar.UiRefNumber is not null ? aadhaar?.Longitude : string.Empty,
                UI_Ref_Number = aadhaar.UiRefNumber is not null ? aadhaar?.UiRefNumber : string.Empty,
                Tran_Identifier = aadhaar.UiRefNumber is not null ? aadhaar?.TranIdentifier : string.Empty
            };
            XmlSerializer xsSubmit = new XmlSerializer(typeof(AuthXmlCreationLevelAuaRd));

            using (StringWriter sww = new())
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                bool includeNameSpace = false;
                if (!includeNameSpace)
                {
                    XmlDocument xDoc = new();
                    XmlSerializerNamespaces namespaces = new();
                    namespaces.Add("", "http://tempuri.org/");
                    xsSubmit.Serialize(writer, authXml, namespaces);
                    xDoc.LoadXml(sww.ToString());
                    var data = sww.ToString();
                    string remove = "<?xml version=" + Convert.ToChar(34).ToString() + "1.0" + Convert.ToChar(34).ToString() + " encoding=" + Convert.ToChar(34).ToString() + "utf-16" + Convert.ToChar(34).ToString() + "?>";
                    data = data.Replace(remove, "");
                    StringBuilder builder = new();
                    builder.Append("<s:Envelope xmlns:s=" + "'http://schemas.xmlsoap.org/soap/envelope/'" + ">" + "<s:Body xmlns:xsi=" + "'http://www.w3.org/2001/XMLSchema-instance'" + " " + "xmlns:xsd=" + "'http://www.w3.org/2001/XMLSchema'" + ">");
                    builder.Replace("'", Convert.ToChar(34).ToString());
                    builder.Append(data);
                    builder.Append("</s:Body></s:Envelope>");
                    return builder.ToString();
                }
            }
            return string.Empty;
        }

        internal static string AuthTxn()
        {
            return $"{DateTime.Now:yyyyMM}{DateTime.Today.DayOfYear:000}{DateTime.Now:HHmmssfffff}";
        }

    }
}
