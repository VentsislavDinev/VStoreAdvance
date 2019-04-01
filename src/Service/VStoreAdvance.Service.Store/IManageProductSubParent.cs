using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductSubParent
    {
        Task CreateProduct(ProductCategoryViewModel model, string id);
        Task DeleteProduct(ProductCategoryViewModel model, string id);
        Task UpdateProduct(ProductCategoryViewModel model, string id);
    }
}