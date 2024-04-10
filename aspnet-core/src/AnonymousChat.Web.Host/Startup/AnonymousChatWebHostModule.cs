using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AnonymousChat.Configuration;

namespace AnonymousChat.Web.Host.Startup
{
    [DependsOn(
       typeof(AnonymousChatWebCoreModule))]
    public class AnonymousChatWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AnonymousChatWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AnonymousChatWebHostModule).GetAssembly());
        }
    }
}
