using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyCollegeV2.MultiTenancy;

namespace MyCollegeV2.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
