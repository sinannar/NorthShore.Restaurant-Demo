using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NorthShore.Restaurant.Roles.Dto;

namespace NorthShore.Restaurant.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
