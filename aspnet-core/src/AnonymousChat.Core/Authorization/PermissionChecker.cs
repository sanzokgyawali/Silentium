using Abp.Authorization;
using AnonymousChat.Authorization.Roles;
using AnonymousChat.Authorization.Users;

namespace AnonymousChat.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
