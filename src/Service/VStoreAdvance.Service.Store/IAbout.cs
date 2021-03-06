﻿namespace VAgency.Service.User.Company
{
    using Abp.Application.Services;
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAbout : IApplicationService
    {
        IEnumerable<About> GetAll();

        Task<About> Create(string name, string desc, DateTime createdOn);

        Task<About> Update(int id, string name, string desc, DateTime createdOn);

        Task<About> Delete(int id, DateTime createdOn);
        
    }
}