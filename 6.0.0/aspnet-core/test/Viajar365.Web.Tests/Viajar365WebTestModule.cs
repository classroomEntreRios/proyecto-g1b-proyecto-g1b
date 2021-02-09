using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Viajar365.EntityFrameworkCore;
using Viajar365.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Viajar365.Web.Tests
{
    [DependsOn(
        typeof(Viajar365WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class Viajar365WebTestModule : AbpModule
    {
        public Viajar365WebTestModule(Viajar365EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Viajar365WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(Viajar365WebMvcModule).Assembly);
        }
    }
}