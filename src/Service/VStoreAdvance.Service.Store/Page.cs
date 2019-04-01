namespace VAgency.Service.User
{
    using Abp.Application.Services;
    using Abp.Domain.Repositories;
    using HostingStore.Products.Company;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    using VAgency.Services.Static;
    using VStoreAdvance.Web.Common.Crypto;

    public class Page : ApplicationService, IPage
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepository<StaticPage> _repository;

        private  ISanitizer _sanitize = new HtmlSanitizerAdapter();
  

        private IRepository<StaticPage> Repository { get => _repository; set => _repository = value; }
        private ISanitizer Sanitize { get => _sanitize; set => _sanitize = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="userSystemData">The user system data.</param>
        /// <param name="repo">The repo.</param>
        public Page(IRepository<StaticPage> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            this.Repository = repo;
        }
               

        /// <summary>
        /// Gets all.
        /// </summary>
        public IEnumerable<StaticPage> GetAll()
        {
            var getAll = this.Repository.GetAll();

            return getAll;
        }

        /// <summary>
        /// Creates the specified created on.
        /// </summary>
        /// <param name="createdOn">The created on.</param>
        /// <param name="name">The name.</param>
        /// <param name="desc">The desc.</param>
        public async Task<StaticPage> Create(DateTime createdOn, string name, string desc)
        {
            var newPage = new StaticPage
            {
                CreatedOn = createdOn,
                Name = name,
                Description = this.Sanitize.Sanitize(desc)
            };
            await this.Repository.InsertAsync(newPage);
          

            return newPage;
        }

        public async Task<StaticPage> Update(int id)
        {
            var newPage =
                this.Repository.GetAll().Where(x=>x.Id == id).FirstOrDefault();
            //newPage.PreserveCreatedOn = true;
           await  this.Repository.UpdateAsync(newPage);
          

            return newPage;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="createdOn"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StaticPage> Delete(DateTime createdOn, int id)
        {
            var newPage = this.Repository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            newPage.IsDeleted = true;
            newPage.DeletedOn = createdOn;

           await  this.Repository.DeleteAsync(newPage);


            return newPage;
        }    
    }
}