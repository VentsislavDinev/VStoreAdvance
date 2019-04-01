using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductCategory
    {
        Task CreateProduct(ProductCategoryViewModel model);
        Task CreateProductCategory(ProductCategoryViewModel model, int categoryId);
        Task CreateProductParrentCategory(ProductCategoryViewModel model, int categoryId);
        Task DeleteProduct(ProductCategoryViewModel model);
        Task UpdateProduct(ProductCategoryViewModel model);
    }
}