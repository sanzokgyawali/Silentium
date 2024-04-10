using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AnonymousChat.EntityFrameworkCore;
using AnonymousChat.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AnonymousChat.Web.Tests
{
    [DependsOn(
        typeof(AnonymousChatWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AnonymousChatWebTestModule : AbpModule
    {
        public AnonymousChatWebTestModule(AnonymousChatEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AnonymousChatWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AnonymousChatWebMvcModule).Assembly);
        }
    }
}