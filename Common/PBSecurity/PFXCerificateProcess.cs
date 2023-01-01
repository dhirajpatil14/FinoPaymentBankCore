using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PBSecurity
{
    public static class PFXCerificateProcess
    {
        static Byte[] keyFileContent;
        static AsymmetricKeyParameter privateKey = null;
        static AsymmetricKeyParameter publicKey = null;
        static X509CertificateEntry[] certificateChain = null;
        public static AsymmetricKeyParameter[] GetCertificateKeyPair(string filePath, string passCode)
        {
            AsymmetricKeyParameter[] objAsymmetricKeyParameter = new AsymmetricKeyParameter[2];
            keyFileContent = PFXCerificateProcess.ReadFile(filePath);
            MemoryStream ms = new MemoryStream(keyFileContent);

            Pkcs12Store store = new Pkcs12Store();

            store.Load(ms, passCode.ToCharArray());

            string alias = store.Aliases.Cast<string>().FirstOrDefault(n => store.IsKeyEntry(n));

            if (alias == null)
                throw new NotImplementedException("Alias Not Found");

            privateKey = store.GetKey(alias).Key;

            certificateChain = store.GetCertificateChain(alias);
            if (certificateChain == null)
                throw new NotImplementedException("Certificate");

            X509Certificate publickeyCertificate = (X509Certificate)(certificateChain[(certificateChain.Length - 1)]).Certificate;

            publicKey = publickeyCertificate.GetPublicKey();
            objAsymmetricKeyParameter[0] = privateKey;
            objAsymmetricKeyParameter[1] = publicKey;

            return objAsymmetricKeyParameter;
        }

        private static byte[] ReadFile(string fileName)
        {
            FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int size = (int)f.Length;
            byte[] data = new byte[size];
            size = f.Read(data, 0, size);
            f.Close();
            return data;
        }
    }
}
