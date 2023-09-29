using System.Threading.Tasks;
using MyCollegeV2.Configuration.Dto;

namespace MyCollegeV2.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
