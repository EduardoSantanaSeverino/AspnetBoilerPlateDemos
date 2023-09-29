using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyCollegeV1.Configuration.Dto;

namespace MyCollegeV1.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyCollegeV1AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
