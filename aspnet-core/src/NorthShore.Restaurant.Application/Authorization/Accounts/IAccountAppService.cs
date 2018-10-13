using System.Threading.Tasks;
using Abp.Application.Services;
using NorthShore.Restaurant.Authorization.Accounts.Dto;

namespace NorthShore.Restaurant.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
