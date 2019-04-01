namespace VAgency.Service.User.Company
{
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VAgency.Data.ViewModels;

    public interface IFeedBackCompany
    {
        Task<CompanyFeedBackCompany> Create(CompanyFeedBackCompanyViewModel Collection);

        Task<CompanyFeedBackCompany> Delete(DateTime createdOn, int id);

        IEnumerable<CompanyFeedBackCompany> GetAll();

        Task<CompanyFeedBackCompany> Update(CompanyFeedBackCompanyViewModel collection, int id);
    }
}