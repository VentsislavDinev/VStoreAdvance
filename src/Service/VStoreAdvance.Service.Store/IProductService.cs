using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Abp.Application.Services;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductService : IApplicationService
    {
        //Task<Product> ParentCreate(string name, string description, decimal? realPrice, decimal price, DateTime createdOn, DateTime? startPromo, TimeSpan? endPromo, decimal? promoPrice, string file, int id, int categoryId  , string brand);
        Task<Product> Create(string name, string description,
            decimal? realPrice, decimal price, 
            DateTime? createdOn, DateTime? startPromo, 
            TimeSpan? endPromo, decimal? promoPrice, 
            string file, ICollection<string> specification, ICollection<string> category, ICollection<string> specificationDetail, ICollection<string> brand);
        Task<Product> Delete(string name, string description, decimal? realPrice, decimal price, DateTime? createdOn, DateTime? startPromo, TimeSpan? endPromo, decimal? promoPrice, string file, int id, int categoryId, string brand);
        IQueryable<Product> GetAll();
        IQueryable<Product> GetById(int id);
        IQueryable<Product> GetByName(string name);
        Task<Product> Update(string name, string description, decimal? realPrice, decimal price, DateTime? createdOn, DateTime? startPromo, TimeSpan? endPromo, decimal? promoPrice, string file, int id, int categoryId, string brand);
    }
}