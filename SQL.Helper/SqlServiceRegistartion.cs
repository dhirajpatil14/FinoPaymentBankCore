using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SQL.Helper
{
    public static class SqlServiceRegistartion
    {
        public static void AddSqlConnectionService(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<SqlConnectionStrings>((opt =>
            {
                opt.PBConfigurationConnection = configuration.GetSection("ConnectionStrings:PBConfigurationConnection").Value.ToDBStringDecrypt();
                opt.PBLogsConnection = configuration.GetSection("ConnectionStrings:PBLogsConnection").Value.ToDBStringDecrypt();
                opt.PBMasterConnection = configuration.GetSection("ConnectionStrings:PBMasterConnection").Value.ToDBStringDecrypt();
                opt.PBtransactionInfoConnection = configuration.GetSection("ConnectionStrings:PBtransactionInfoConnection").Value.ToDBStringDecrypt();
            }));

        }

        public static string ToDBStringDecrypt(this string cipherText)
        {

            var key = "E546C8DF278CD5931069B522E695D4F2";

            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using MemoryStream memoryStream = new MemoryStream(buffer);
            using CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader((Stream)cryptoStream);
            return streamReader.ReadToEnd();
        }
    }
}
