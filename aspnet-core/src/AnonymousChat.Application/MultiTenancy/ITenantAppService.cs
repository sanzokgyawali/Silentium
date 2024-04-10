using Abp.Application.Services;
using AnonymousChat.MultiTenancy.Dto;

namespace AnonymousChat.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

