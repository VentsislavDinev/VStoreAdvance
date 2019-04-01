using Abp.Authorization.Roles;
using VStoreAdvance.Infrastructure.Core.Users;

namespace VStoreAdvance.Infrastructure.Core.Authorization.Roles
{

    /// <summary>
    /// The role.
    /// </summary>
    public class Role : AbpRole<User>
    {
        public Role()
        {

        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
    }
}
