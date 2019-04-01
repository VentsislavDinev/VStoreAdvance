using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductImage : IApplicationService
    {
        Task CreateProduct(ProductImageListViewModel model, string image);
        Task DeleteProduct(ProductImageListViewModel model, string image);
        Task UpdateProduct(ProductImageListViewModel model, string image);
    }
}