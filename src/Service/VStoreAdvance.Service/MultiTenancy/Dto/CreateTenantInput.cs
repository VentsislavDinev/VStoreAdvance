using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VStoreAdvance.Infrastructure.Core.MultiTenancy;
using VStoreAdvance.Infrastructure.Core.Users;

namespace VStoreAdvance.Service.MultiTenancy.Dto
{

    public class CreateTenantInput
    {
        /// <summary>
        /// Gets or sets the tenancy name.
        /// </summary>
        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        [RegularExpression(Tenant.TenancyNameRegex)]
        public string TenancyName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(Tenant.MaxNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the admin email address.
        /// </summary>
        [Required]
        [StringLength(User.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }
    }
}
