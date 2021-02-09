using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Viajar365.Authorization;

namespace Viajar365
{
    [DependsOn(
        typeof(Viajar365CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Viajar365ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Viajar365AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Viajar365ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
