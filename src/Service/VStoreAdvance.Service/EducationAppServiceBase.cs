using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using VStoreAdvance.Infrastructure.Core;
using VStoreAdvance.Infrastructure.Core.MultiTenancy;
using VStoreAdvance.Infrastructure.Core.Users;

namespace VStoreAdvance.Service
{

    /// <summary>
    /// The education app service base.
    /// </summary>
    public class VStoreAdvanceAppServiceBase : ApplicationService
    {
        /// <summary>
        /// Gets or sets the tenant manager.
        /// </summary>
        public TenantManager TenantManager { get; set; }

        /// <summary>
        /// Gets or sets the user manager.
        /// </summary>
        public UserManager UserManager { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EducationAppServiceBase"/> class.
        /// </summary>
        protected VStoreAdvanceAppServiceBase()
        {
            LocalizationSourceName = VStoreAdvanceConsts.LocalizationSourceName;
        }

        /// <summary>
        /// The get current tenant async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        /// <summary>
        /// The get current user async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        /// <summary>
        /// The check errors.
        /// </summary>
        /// <param name="identityResult">
        /// The identity result.
        /// </param>
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
