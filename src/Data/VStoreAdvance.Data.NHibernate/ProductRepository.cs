using Abp.NHibernate;
using Abp.NHibernate.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VStoreAdvance.Data.NHibernate
{
    public class ProductRepository : NhRepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public List<Product> GetAllBlog()
        {
            var query = GetAll();


            return query
                .OrderByDescending(task => task.CreatedOn)
                .ToList();
        }
    }
}
