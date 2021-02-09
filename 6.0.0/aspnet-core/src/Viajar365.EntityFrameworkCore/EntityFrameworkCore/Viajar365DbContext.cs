using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Viajar365.Authorization.Roles;
using Viajar365.Authorization.Users;
using Viajar365.MultiTenancy;

namespace Viajar365.EntityFrameworkCore
{
    public class Viajar365DbContext : AbpZeroDbContext<Tenant, Role, User, Viajar365DbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public Viajar365DbContext(DbContextOptions<Viajar365DbContext> options)
            : base(options)
        {
        }
    }
}
