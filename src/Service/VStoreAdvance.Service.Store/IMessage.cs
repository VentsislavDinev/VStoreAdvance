namespace VAgency.Service.User.Company
{
    using Abp.Application.Services;
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VAgency.Data.ViewModels.Company;

    public interface IMessageCompany : IApplicationService
    {
        IEnumerable<CompanyMessage> GetAll();

        Task<CompanyMessage> Delete(int id, DateTime createdOn);

        Task<CompanyMessage> Update(CompanyMessageViewViewModel collection, int id);

        Task<CompanyMessage> Create(CompanyMessageCreateViewViewModel collection);              
    }
}