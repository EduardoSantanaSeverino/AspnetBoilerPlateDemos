using Abp.Authorization;
using MyCollegeV2.Authorization.Roles;
using MyCollegeV2.Authorization.Users;

namespace MyCollegeV2.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
