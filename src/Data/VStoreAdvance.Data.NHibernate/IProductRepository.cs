using System.Collections.Generic;
using Abp.Domain.Repositories;
using HostingStore.Products;

namespace VStoreAdvance.Data.NHibernate
{
    public interface IProductRepository : IRepository<Product, int>
    {
        List<Product> GetAllBlog();
    }
}