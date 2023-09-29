using System.Threading.Tasks;
using MyCollegeV1.Configuration.Dto;

namespace MyCollegeV1.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
