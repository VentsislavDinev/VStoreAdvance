using Abp.Application.Services;
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VAgency.Service.User.Company
{
    public class CompanyLogoService : ApplicationService, ICompanyLogoService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyLogo> _repo;

        private IRepository<CompanyLogo> Repo { get => _repo; set => _repo = value; }

        public CompanyLogoService(IRepository<CompanyLogo> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }

            Repo = repo;
        }

        public IEnumerable<CompanyLogo> GetAll()
        {
            return Repo.GetAll();
        }

        public IEnumerable<CompanyLogo> GetById(int id)
        {
            return Repo.GetAll().Where(x => x.Id == id);
        }

        public async Task<CompanyLogo> Create(string filePath,
            string title)
        {
            CompanyLogo avatar = new CompanyLogo
            {
                FileName = filePath,
                Title = title
            };

            await Repo.InsertAsync(avatar);


            return avatar;
        }

        public async Task<CompanyLogo> Update(int id, string filePath, string title)
        {
            CompanyLogo avatar = new CompanyLogo
            {
                FileName = filePath,
                Title = title,
            };
            await Repo.UpdateAsync(avatar);

            return avatar;
        }

        public async Task<CompanyLogo> Delete(int id, DateTime deletedOn)
        {
            CompanyLogo avatar = new CompanyLogo
            {
                DeletedOn = deletedOn,
                IsDeleted = true
            };

            await Repo.DeleteAsync(avatar);

            return avatar;
        }
    }
}