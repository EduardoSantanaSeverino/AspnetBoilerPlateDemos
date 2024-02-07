using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MyCollegeV2.Authorization
{
    public class MyCollegeV2AuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Students, L("Students"));
///AuthorizationProvider.cs.place1///
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyCollegeV2Consts.LocalizationSourceName);
        }
    }
}

