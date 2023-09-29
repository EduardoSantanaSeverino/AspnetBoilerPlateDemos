using Abp.Application.Services;
using MyCollegeV2.MultiTenancy.Dto;

namespace MyCollegeV2.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

