using Abp.Application.Services.Dto;

namespace AnonymousChat.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

