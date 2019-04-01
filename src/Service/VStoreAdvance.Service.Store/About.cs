namespace VAgency.Service.User.Company
{
    using Abp.Application.Services;
    using Abp.Domain.Repositories;
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using VStoreAdvance.Web.Common.Crypto;

    public class AboutSevice : ApplicationService, IAbout
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<About> _repo;

        private ISanitizer _sanitize;
        private IRepository<About> Repo { get => _repo; set => _repo = value; }
        private ISanitizer Sanitize { get => _sanitize; set => _sanitize = value; }

        public AboutSevice(ISanitizer sanitizer, IRepository<About> repo)
        {
            this.Repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.Sanitize = sanitizer ?? throw new ArgumentNullException(nameof(sanitizer));
        }

        /// <summary>
        /// Gets all.
        /// </summary>s
        public IEnumerable<About> GetAll()
        {
           
            return this.Repo.GetAll();
        }

        /// <summary>

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="desc">The desc.</param>
        public async Task<About> Create(string name, string desc, DateTime createdOn)
        {
            var newabout = new About
            {
                Name = name,
                Description = this.Sanitize.Sanitize(desc),
                CreatedOn = createdOn,
            };
            
                await this.Repo.InsertAsync(newabout);
          

            return newabout;
        }

        /// <summary>
        /// Updates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="desc">The desc.</param>
        public async Task<About> Update(int id, string name, string desc, DateTime createdOn)
        {
            var newabout = new About
            {
                Name = name,

                Description = this.Sanitize.Sanitize(desc),

                PreserveCreatedOn = true
            };
            
                await this.Repo.UpdateAsync(newabout);
            

            return newabout;
        }

        /// <summary>
        /// Deletes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="desc">The desc.</param>
        public async Task<About> Delete(int id, DateTime createdOn)
        {
            var newabout = new About
            {
                DeletedOn = createdOn,
                IsDeleted = true,
            };
            
                await this.Repo.DeleteAsync(newabout);
            
            return newabout;
        }

    }
}