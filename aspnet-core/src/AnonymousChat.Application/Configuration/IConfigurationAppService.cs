using System.Threading.Tasks;
using AnonymousChat.Configuration.Dto;

namespace AnonymousChat.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
