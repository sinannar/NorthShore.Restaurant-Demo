using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NorthShore.Restaurant.MultiTenancy.Dto;

namespace NorthShore.Restaurant.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
