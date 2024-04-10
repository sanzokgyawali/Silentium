using System.Threading.Tasks;
using Abp.Application.Services;
using AnonymousChat.Sessions.Dto;

namespace AnonymousChat.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
