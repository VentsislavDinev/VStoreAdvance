namespace VAgency.Service.User.Company
{
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VAgency.Data.ViewModels;

    public interface IContact
    {
        Task<CompanyContact> Create(CompanyContactViewModel collection, DateTime createdOn);

        Task<CompanyContact> Update(CompanyContactViewModel collection);

        Task<CompanyContact> Delete(int id, DateTime deletedOn);

        IEnumerable<CompanyContact> GetAll();
    }
}