using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NorthShore.Restaurant.Authorization;

namespace NorthShore.Restaurant
{
    [DependsOn(
        typeof(RestaurantCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class RestaurantApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<RestaurantAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(RestaurantApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
