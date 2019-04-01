namespace VAgency.Service.User.Company
{
    using Abp.Application.Services;
    using Abp.Domain.Repositories;
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VAgency.Data.ViewModels;

    public class Service :ApplicationService, IService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyInformation> _repo;

        public IRepository<CompanyInformation> Repo { get => _repo; set => _repo = value; }


        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyContactQuery" /> class.
        /// </summary>
        /// <param name="companySystemData">The company system data.</param>
        /// <param name="repo">The repo.</param>
        public Service(IRepository<CompanyInformation> repo)
        {
            this.Repo = repo ?? throw new ArgumentNullException("repo is null or empty");
        }

        /// <summary>
        /// Creates the specified desc.
        /// </summary>
        /// <param name="desc">The desc.</param>
        /// <param name="name">The name.</param>
        public async Task<CompanyInformation> Create(CompanyInformationViewViewModel collection, string file)
        {
            var newinfo = new CompanyInformation
            {
                Description = collection.Description,
                Name = collection.Name,   
                FilePath = file
            };

          await   this.Repo.InsertAsync(newinfo);
           
            return newinfo;
        }

        /// <summary>
        /// Updates the specified desc.
        /// </summary>
        /// <param name="desc">The desc.</param>
        /// <param name="name">The name.</param>
        public async Task<CompanyInformation> Update(CompanyInformationViewViewModel collection, int id)
        {
            var newinfo = new CompanyInformation
            {
                Description = collection.Description,
                Name = collection.Name,
                PreserveCreatedOn = true,
            };

            //newinfo = this.Repo.GetById(id);

            await this.Repo.UpdateAsync(newinfo);
            
            return newinfo;
        }

        /// <summary>
        /// Deletes the specified desc.
        /// </summary>
        /// <param name="desc">The desc.</param>
        /// <param name="name">The name.</param>
        public async Task<CompanyInformation> Delete(int id, DateTime createdOn)
        {
            var newinfo = new CompanyInformation
            {
                IsDeleted = true,
                DeletedOn = createdOn,
            };

            //newinfo = this.Repo.GetById(id);

           await  this.Repo.DeleteAsync(newinfo);
           
            return newinfo;
        }

        /// <summary>
        /// Gets all.
        /// </summary>s
        public IEnumerable<CompanyInformation> GetAll()
        {
            var getAllContact = this.Repo.GetAll();

            return getAllContact;
        }
    
    }
}