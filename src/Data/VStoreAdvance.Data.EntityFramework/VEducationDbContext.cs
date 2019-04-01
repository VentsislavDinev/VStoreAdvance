using System.Data.Common;
using System.Data.Entity;
using VStoreAdvance.Infrastructure.Core.MultiTenancy;
using VStoreAdvance.Infrastructure.Core.Users;
using VStoreAdvance.Infrastructure.Core.Authorization.Roles;
using Abp.Zero.EntityFramework;
using HostingStore.Products;
using HostingStore.Products.Company;

namespace VStoreAdvance.Data.EntityFramework
{
    /// <summary>
    /// The education db context.
    /// </summary>

    public class VStoreAdvanceDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public DbSet<ProductSpecificationDetail> ProductSpecificationDetails { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPromoHome> ProductPromoHomes { get; set; }
        public DbSet<DeleveryInformation> DeleveryInformations { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        //public DbSet<ProductSubParrentCategory> ProductSubParrentCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        
        //public DbSet<CompanyImage> CompanyImage { get; set; }
        public DbSet<CompanyContact> CompanyContacts { get; set; }
        public DbSet<CompanyFeedBackClient> CompanyFeedBackClients { get; set; }
        public DbSet<CompanyFeedBackCompany> CompanyFeedBackCompanies { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }
        public DbSet<CompanyLogo> CompanyLogos { get; set; }
        public DbSet<CompanyMessage> CompanyMessages { get; set; }
        public DbSet<StaticPageURL> StaticPageUrls { get; set; }
        public DbSet<StaticPageUrlImage> StaticPageUrlImages { get; set; }
        public DbSet<StaticPage> StaticPages { get; set; }
        public DbSet<About> Abouts { get; set; }
        

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public VStoreAdvanceDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EducationDbContext"/> class.
        ///  This constructor is used by ABP to pass connection string defined in InterceptionDemoDataModule.PreInitialize.
        /// Notice that, actually you will not directly create an instance of InterceptionDemoDbContext since ABP automatically handles it.
        /// </summary>
        /// <param name="nameOrConnectionString">
        /// The name or connection string.
        /// </param>
        public VStoreAdvanceDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        //This constructor is used in tests
        public VStoreAdvanceDbContext(DbConnection connection)
            : base(connection, true)
        {
        }
    }
}
