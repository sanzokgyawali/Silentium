﻿using Abp.Dependency;
using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using AnonymousChat.AppUser.Helper;
using AnonymousChat.Authorization.Roles;
using AnonymousChat.Authorization.Users;
using AnonymousChat.Configuration;
using AnonymousChat.Localization;
using AnonymousChat.MultiTenancy;
using AnonymousChat.Timing;

namespace AnonymousChat
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AnonymousChatCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AnonymousChatLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AnonymousChatConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = AnonymousChatConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = AnonymousChatConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AnonymousChatCoreModule).GetAssembly());
            IocManager.Register<GenerateOTP>(DependencyLifeStyle.Transient); //GenerateUserDetails
            IocManager.Register<GenerateUserDetails>(DependencyLifeStyle.Transient); //GenerateUserDetails
            IocManager.Register<JWT>(DependencyLifeStyle.Transient); 


        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
