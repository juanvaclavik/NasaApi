using NasaApi.Services.ServiceResult;
using System.Threading.Tasks;

namespace NasaApi.Services
{
    public interface IService
    {
        Task<ServiceResult<T>> GetData<T>(string url);
    }
}
