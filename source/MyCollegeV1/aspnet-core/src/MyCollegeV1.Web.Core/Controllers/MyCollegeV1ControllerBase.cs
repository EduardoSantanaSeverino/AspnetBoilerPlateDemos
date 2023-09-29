using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyCollegeV1.Controllers
{
    public abstract class MyCollegeV1ControllerBase: AbpController
    {
        protected MyCollegeV1ControllerBase()
        {
            LocalizationSourceName = MyCollegeV1Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
