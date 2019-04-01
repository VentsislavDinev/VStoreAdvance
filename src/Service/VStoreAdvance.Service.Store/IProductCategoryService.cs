using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductCategoryService : IApplicationService
    {
        Task<ProductCategory> Create(string category);

        Task<ProductCategory> CreateParrentCategory(string category, int categoryId);
        
        Task<ProductCategory> CreateCategory(string category, int categoryId);
        Task<ProductCategory> Delete(string category);
        IQueryable<ProductCategory> GetAll();
        IQueryable<ProductCategory> GetById(int id);
        IQueryable<ProductCategory> GetByName(string category);
        Task<ProductCategory> Update(string category);
    }
}