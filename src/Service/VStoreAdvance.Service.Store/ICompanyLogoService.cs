using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VAgency.Service.User.Company
{
    public interface ICompanyLogoService
    {
        Task<CompanyLogo> Create(string filePath,  string title);

        Task<CompanyLogo> Delete(int id, DateTime deletedOn);

        IEnumerable<CompanyLogo> GetAll();

        IEnumerable<CompanyLogo> GetById(int id);

        Task<CompanyLogo> Update(int id, string filePath, string title);
    }
}