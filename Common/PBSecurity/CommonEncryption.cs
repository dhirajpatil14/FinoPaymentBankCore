using Common.Application.Interface;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using PBSecurity.Application;
using PBSecurity.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PBSecurity
{
    public class CommonEncryption
    {
        private static string CertificatePathNew = string.Empty;
        private readonly IPBSecurityRepository _pbSecurityRepository;
        public CommonEncryption(IPBSecurityRepository pbSecurityRepository)
        {
            _pbSecurityRepository = pbSecurityRepository;
        }

        public async Task<PBSecurityResponse> LoginRequest(IEncryptInRequest request, string value = "")
        {
            string Key = SecurityCertificateValue.SecurityKey;
            var outres = new PBSecurityResponse(); // comment
            string CertificatePath = String.Empty;
            string SK = String.Empty;

            //DecrypRSA(EncryptedString)
            // 1. Decript From Private Key of SK. 
            //Add logic to change process with CertificatId
            if (request.CertificateId != null)
            {
                
                //var data = await _pbSecurityRepository.GetValidCertificate(Convert.ToInt16(request.AppChannelId), request.CertificateId);
                var data = (clsDictionaryMethod.SecurityProductGetValue(Key) == null || clsDictionaryMethod.SecurityProductGetValue(Key)) == "" ? await _pbSecurityRepository.GetValidCertificate(Convert.ToInt16(request.AppChannelId), request.CertificateId) : clsDictionaryMethod.SecurityProductGetValue(Key);
                clsDictionaryMethod.SecurityProductAdd(Key, data);

                if(data is not null)
                {
                    if(Convert.ToDateTime(data.KeyExpiryDate) >= DateTime.Now)
                    {
                        CertificatePath = data.CertificatePath + data.CertificateName;
                        SK = DecryptRsa(request.sessionId, CertificatePath, true, Convert.ToString(data.CertificatePassword).ToDecryptStringAES(data.CertificateId, Key));
                    }
                    else
                    {
                        outres = new PBSecurityResponse()
                        {
                            isValid = false,
                            message = SecurityCertificateValue.DownloadValidCert,
                            ResponseCode = "5004",
                        };
                        return outres;
                    }
                }
                else
                {
                    outres = new PBSecurityResponse()
                    {
                        isValid = false,
                        message = SecurityCertificateValue.InvalidCert,
                        ResponseCode = "5007",
                    };
                    return outres;
                }
            }
            else 
            {
                var data = (clsDictionaryMethod.SecurityProductGetValue(Key) == null || clsDictionaryMethod.SecurityProductGetValue(Key)) == "" ? await _pbSecurityRepository.GetValidCertificate(0) : clsDictionaryMethod.SecurityProductGetValue(Key);
                clsDictionaryMethod.SecurityProductAdd(Key, data);
                if(data is not null)
                {
                    if (Convert.ToDateTime(data.KeyExpiryDate) >= DateTime.Now)
                    {
                        CertificatePath = data.CertificatePath + data.CertificateName;
                    }
                    else
                    {
                        outres = new PBSecurityResponse()
                        {
                            isValid = false,
                            message = SecurityCertificateValue.DownloadValidCert,
                            ResponseCode = "5004",
                        };
                        return outres;
                    }
                }
                SK = DecryptRsa(request.sessionId, CertificatePath);
            }

            outres.SK = SK;
            // 2. Based on SK Decrypt Payload Data and hash value.



            return outres; //comment
        }

        public static string DecryptRsa(string base64Input, string path, bool IsValidCertificate = false, string passCode = "")
        {
            AsymmetricCipherKeyPair keyPair;
            var bytesToDecrypt = Convert.FromBase64String(base64Input);
            if(IsValidCertificate)
            {
                AsymmetricKeyParameter[] KeyPair = PFXCerificateProcess.GetCertificateKeyPair(path, passCode);
                keyPair = new AsymmetricCipherKeyPair(KeyPair[1], KeyPair[0]);
            }
            else
            {
                using (var reader = File.OpenText(path))
                    keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
            }
            var decryptEngine = new Pkcs1Encoding(new RsaEngine());
            decryptEngine.Init(false, keyPair.Private);

            var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
            return decrypted;
        }
    }
}
