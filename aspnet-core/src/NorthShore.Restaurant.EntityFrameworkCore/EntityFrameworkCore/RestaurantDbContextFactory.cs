using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NorthShore.Restaurant.Configuration;
using NorthShore.Restaurant.Web;

namespace NorthShore.Restaurant.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class RestaurantDbContextFactory : IDesignTimeDbContextFactory<RestaurantDbContext>
    {
        public RestaurantDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RestaurantDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            RestaurantDbContextConfigurer.Configure(builder, configuration.GetConnectionString(RestaurantConsts.ConnectionStringName));

            return new RestaurantDbContext(builder.Options);
        }
    }
}
