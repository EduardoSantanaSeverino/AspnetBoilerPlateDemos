using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyCollegeV2.Configuration.Dto;

namespace MyCollegeV2.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyCollegeV2AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
