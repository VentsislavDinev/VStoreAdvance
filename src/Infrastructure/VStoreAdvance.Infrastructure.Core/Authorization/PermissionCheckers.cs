using Abp.Authorization;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VStoreAdvance.Infrastructure.Core.Users;
using VStoreAdvance.Infrastructure.Core.Authorization.Roles;

namespace VStoreAdvance.Infrastructure.Core.Authorization
{
    /// <summary>
    /// The permission checker.
    /// </summary>
    public class PermissionCheckers : PermissionChecker<Role, User>
    {
        public PermissionCheckers(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
