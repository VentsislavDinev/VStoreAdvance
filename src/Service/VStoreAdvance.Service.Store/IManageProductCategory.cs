using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductCategory : IApplicationService
    {
        Task CreateProduct(ProductCategoryViewModel model);
        Task CreateProductCategory(ProductCategoryViewModel model, int categoryId);
        Task CreateProductParrentCategory(ProductCategoryViewModel model, int categoryId);
        Task DeleteProduct(ProductCategoryViewModel model);
        Task UpdateProduct(ProductCategoryViewModel model);
    }
}