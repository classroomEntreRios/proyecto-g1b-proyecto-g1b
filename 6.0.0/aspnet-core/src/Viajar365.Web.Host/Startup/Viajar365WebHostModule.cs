using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Viajar365.Configuration;

namespace Viajar365.Web.Host.Startup
{
    [DependsOn(
       typeof(Viajar365WebCoreModule))]
    public class Viajar365WebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Viajar365WebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Viajar365WebHostModule).GetAssembly());
        }
    }
}
