using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyCollegeV2.Controllers
{
    public abstract class MyCollegeV2ControllerBase: AbpController
    {
        protected MyCollegeV2ControllerBase()
        {
            LocalizationSourceName = MyCollegeV2Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
