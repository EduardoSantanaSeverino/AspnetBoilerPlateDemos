using System.Threading.Tasks;
using Abp.Application.Services;
using MyCollegeV2.Sessions.Dto;

namespace MyCollegeV2.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
