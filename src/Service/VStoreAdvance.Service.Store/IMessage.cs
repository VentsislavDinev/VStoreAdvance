namespace VAgency.Service.User.Company
{
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VAgency.Data.ViewModels.Company;

    public interface IMessageCompany
    {
        IEnumerable<CompanyMessage> GetAll();

        Task<CompanyMessage> Delete(int id, DateTime createdOn);

        Task<CompanyMessage> Update(CompanyMessageViewViewModel collection, int id);

        Task<CompanyMessage> Create(CompanyMessageCreateViewViewModel collection);              
    }
}