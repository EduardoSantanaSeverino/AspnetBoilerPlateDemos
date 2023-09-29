using Abp.Application.Services;
using MyCollegeV1.MultiTenancy.Dto;

namespace MyCollegeV1.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

