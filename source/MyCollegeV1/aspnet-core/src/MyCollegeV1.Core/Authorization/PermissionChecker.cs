using Abp.Authorization;
using MyCollegeV1.Authorization.Roles;
using MyCollegeV1.Authorization.Users;

namespace MyCollegeV1.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
