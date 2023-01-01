using PBSecurity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBSecurity.Application
{
    public interface IPBSecurityRepository
    {
        Task<MstSSLCertificate> GetValidCertificate(int appChannelId, string certificateId = "");
    }
}
