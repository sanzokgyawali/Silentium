using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AnonymousChat.Authorization;



namespace AnonymousChat
{
    [DependsOn(
        typeof(AnonymousChatCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AnonymousChatApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AnonymousChatAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AnonymousChatApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)


            );

            

           
        }

       

    }
}
