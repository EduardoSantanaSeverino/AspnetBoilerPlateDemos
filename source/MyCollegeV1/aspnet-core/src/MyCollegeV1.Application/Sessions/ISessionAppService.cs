using System.Threading.Tasks;
using Abp.Application.Services;
using MyCollegeV1.Sessions.Dto;

namespace MyCollegeV1.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
