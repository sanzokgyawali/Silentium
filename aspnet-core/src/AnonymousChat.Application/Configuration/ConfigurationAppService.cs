using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AnonymousChat.Configuration.Dto;

namespace AnonymousChat.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AnonymousChatAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
