using System.Threading.Tasks;
using Abp.Application.Services;
using NorthShore.Restaurant.Sessions.Dto;

namespace NorthShore.Restaurant.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
