using Abp.Authorization;
using NorthShore.Restaurant.Authorization.Roles;
using NorthShore.Restaurant.Authorization.Users;

namespace NorthShore.Restaurant.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
