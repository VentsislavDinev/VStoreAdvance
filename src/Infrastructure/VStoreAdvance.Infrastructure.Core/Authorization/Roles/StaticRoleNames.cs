using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VStoreAdvance.Infrastructure.Core.Authorization.Roles
{
    /// <summary>
    /// The static role names.
    /// </summary>
    public static class StaticRoleNames
    {
        /// <summary>
        /// The host.
        /// </summary>
        public static class Host
        {
            /// <summary>
            /// The admin.
            /// </summary>
            public const string Admin = "Admin";
        }

        /// <summary>
        /// The tenants.
        /// </summary>
        public static class Tenants
        {
            /// <summary>
            /// The admin.
            /// </summary>
            public const string Admin = "Admin";
        }
    }
}
