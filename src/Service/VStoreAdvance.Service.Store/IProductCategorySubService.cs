using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductCategorySubService : IApplicationService
    {
        Task<ProductSubCategory> Create(string category, int id);
        Task<ProductSubCategory> Delete(string category, int id);
        IQueryable<ProductSubCategory> GetAll();
        IQueryable<ProductSubCategory> GetById(int id);
        IQueryable<ProductSubCategory> GetByName(string category);
        Task<ProductSubCategory> Update(string category, int id);
    }
}