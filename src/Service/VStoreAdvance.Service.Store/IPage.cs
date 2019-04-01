namespace VAgency.Services.Static
{
    using HostingStore.Products.Company;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IPage
    {
        Task<StaticPage> Create(DateTime createdOn, string name, string desc);

        Task<StaticPage> Delete(DateTime createdOn, int id);

        IEnumerable<StaticPage> GetAll();

        Task<StaticPage> Update(int id);
    }
}