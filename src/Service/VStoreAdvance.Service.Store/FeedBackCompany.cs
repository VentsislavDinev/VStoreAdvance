namespace VAgency.Service.User.Company
{
    using Abp.Application.Services;
    using Abp.Domain.Repositories;
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using VAgency.Data.ViewModels;

    public class FeedBackCompany : ApplicationService, IFeedBackCompany
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyFeedBackCompany> _repo;
                              
        public IRepository<CompanyFeedBackCompany> Repo { get => _repo; set => _repo = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyContactQuery" /> class.
        /// </summary>
        /// <param name="companySystemData">The company system data.</param>
        /// <param name="repo">The repo.</param>
        public FeedBackCompany(IRepository<CompanyFeedBackCompany> repo)
        {
            this.Repo = repo ?? throw new ArgumentNullException("repo is null");
        }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="logo">The logo.</param>
        public async Task<CompanyFeedBackCompany> Create(CompanyFeedBackCompanyViewModel collection)
        {
            var newFeedbackComp = new CompanyFeedBackCompany
            {
                CompanyName = collection.CompanyName,
                Description = collection.Description,
                Logo = collection.CompanyLogos,
            };

            await this.Repo.InsertAsync(newFeedbackComp);
           

            return newFeedbackComp;
        }

        /// <summary>
        /// Updates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="logo">The logo.</param>
        public async Task<CompanyFeedBackCompany> Update(CompanyFeedBackCompanyViewModel collection, int id)
        {
            var newFeedbackComp = new CompanyFeedBackCompany
            {
                CompanyName = collection.CompanyName,
                Description = collection.Description,
                Logo = collection.CompanyLogos,
                PreserveCreatedOn = true
            };
            //newFeedbackComp = this.Repo.GetById(id);

            await this.Repo.UpdateAsync(newFeedbackComp);
           
            return newFeedbackComp;
        }

        /// <summary>
        /// Deletes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="logo">The logo.</param>
        public async Task<CompanyFeedBackCompany> Delete(DateTime createdOn, int id)
        {
            //var newFeedbackComp = this.Repo.GetById(id);
            var newFeedbackComp = new CompanyFeedBackCompany()
            {
                IsDeleted = true,
                DeletedOn = createdOn,
            };

            await  this.Repo.DeleteAsync(newFeedbackComp);
            
            return newFeedbackComp;
        }

        /// <summary>
        /// Gets all.
        /// </summary>s
        public IEnumerable<CompanyFeedBackCompany> GetAll()
        {
            var getAllContact = this.Repo.GetAll();
            return getAllContact;
        }

        /// <summary>
        /// Gets the with identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<CompanyFeedBackCompany> GetWithId(int id)
        {
            var getWithId = this.GetAll().Where(x => x.Id == id);
            return getWithId;
        }
          
    }
}