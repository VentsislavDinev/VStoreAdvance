using Abp.Application.Services;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace VAgency.Service.User.Company
{
    public interface IService : IApplicationService
    {
        Task<CompanyInformation> Create(CompanyInformationViewViewModel colection, string file);

        Task<CompanyInformation> Delete(int id, DateTime createdOn);

        IEnumerable<CompanyInformation> GetAll();

        Task<CompanyInformation> Update(CompanyInformationViewViewModel colelctoin, int id);
    }
}