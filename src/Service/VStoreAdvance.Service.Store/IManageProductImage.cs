using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductImage
    {
        Task CreateProduct(ProductImageListViewModel model, string image);
        Task DeleteProduct(ProductImageListViewModel model, string image);
        Task UpdateProduct(ProductImageListViewModel model, string image);
    }
}