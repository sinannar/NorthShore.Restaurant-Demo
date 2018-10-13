using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NorthShore.Restaurant.Authorization.Roles;
using NorthShore.Restaurant.Authorization.Users;
using NorthShore.Restaurant.MultiTenancy;

namespace NorthShore.Restaurant.EntityFrameworkCore
{
    public class RestaurantDbContext : AbpZeroDbContext<Tenant, Role, User, RestaurantDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }
    }
}
