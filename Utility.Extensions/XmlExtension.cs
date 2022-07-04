using Common.Application.Model.EKYC;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Utility.Extensions
{
    public static class XmlExtension
    {
        public static KycResponseRd ToParseOtpRd(this string xml)
        {


            //XmlDocument xmlDocument = new();
            //xmlDocument.LoadXml(xml);

            //XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("Resp");

            return xml.ToXmlReader<KycResponseRd>();



            //var kycResponse = new KycResponseRd
            //{
            //    errCode = xmlNodeList.Cast<XmlNode>().Where(xx => xx.Attributes["errCode"] is not null).Select(xx => xx.Attributes["errCode"].Value).FirstOrDefault(),
            //    errInfo = xmlNodeList.Cast<XmlNode>().Where(xx => xx.Attributes["errInfo"] is not null).Select(xx => xx.Attributes["errInfo"].Value).FirstOrDefault(),
            //    fCount = xmlNodeList.Cast<XmlNode>().Where(xx => xx.Attributes["fCount"] is not null).Select(xx => xx.Attributes["fCount"].Value).FirstOrDefault(),
            //    fType = xmlNodeList.Cast<XmlNode>().Where(xx => xx.Attributes["fType"] is not null).Select(xx => xx.Attributes["fType"].Value).FirstOrDefault(),
            //    iCount = xmlNodeList.Cast<XmlNode>().Where(xx => xx.Attributes["iCount"] is not null).Select(xx => xx.Attributes["iCount"].Value).FirstOrDefault(),
            //    pCount = xmlNodeList.Cast<XmlNode>().Where(xx => xx.Attributes["iCount"] is not null).Select(xx => xx.Attributes["iCount"].Value).FirstOrDefault(),
            //};

        }

        internal static TResponse ToXmlReader<TResponse>(this string value)
        {
            XmlSerializer xMLSerializer = new(typeof(TResponse));
            var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = true, IgnoreComments = true };
            using var xmlReader = XmlReader.Create(new StringReader(value), settings);
            xmlReader.Read();
            return (TResponse)xMLSerializer.Deserialize(xmlReader);
        }
    }
}
