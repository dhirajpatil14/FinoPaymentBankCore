using Common.Application.Model.EKYC;
using System.Threading.Tasks;

namespace Common.Application.Interface
{
    public interface IEkycAuaService
    {
        Task<EkycAuaAadharRd> GetKycAadhar();
    }
}
