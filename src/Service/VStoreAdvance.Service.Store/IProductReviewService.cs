using System;
using System.Linq;
using System.Threading.Tasks;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductReviewService
    {
        Task<ProductReview> Create(string author, string comment, DateTime createdOn);
        Task<ProductReview> Delete(string author, string comment, DateTime createdOn);
        IQueryable<ProductReview> GetAll();
        IQueryable<ProductReview> GetById(int id);
        IQueryable<ProductReview> GetByName(string userName);
        Task<ProductReview> Update(string author, string comment, DateTime createdOn);
    }
}