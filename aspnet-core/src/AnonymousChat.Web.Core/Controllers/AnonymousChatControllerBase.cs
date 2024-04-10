using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AnonymousChat.Controllers
{
    public abstract class AnonymousChatControllerBase: AbpController
    {
        protected AnonymousChatControllerBase()
        {
            LocalizationSourceName = AnonymousChatConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
