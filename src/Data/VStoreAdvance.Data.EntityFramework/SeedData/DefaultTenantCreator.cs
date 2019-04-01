using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VStoreAdvance.Infrastructure.Core.MultiTenancy;

namespace VStoreAdvance.Data.EntityFramework.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly VStoreAdvanceDbContext _context;

        public DefaultTenantCreator(VStoreAdvanceDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant { TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName });
                _context.SaveChanges();
            }
        }
    }
}
