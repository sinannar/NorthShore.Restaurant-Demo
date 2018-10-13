using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace NorthShore.Restaurant.Controllers
{
    public abstract class RestaurantControllerBase: AbpController
    {
        protected RestaurantControllerBase()
        {
            LocalizationSourceName = RestaurantConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
