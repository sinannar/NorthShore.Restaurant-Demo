using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NorthShore.Restaurant.Configuration;

namespace NorthShore.Restaurant.Web.Host.Startup
{
    [DependsOn(
       typeof(RestaurantWebCoreModule))]
    public class RestaurantWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public RestaurantWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RestaurantWebHostModule).GetAssembly());
        }
    }
}
