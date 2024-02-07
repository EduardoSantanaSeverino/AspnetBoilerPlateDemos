using Abp.Application.Services.Dto;

namespace MyCollegeV2.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

