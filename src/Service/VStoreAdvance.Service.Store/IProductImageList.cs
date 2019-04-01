using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductImageList : IApplicationService
    {
        ProductImageListViewModel GetSingleProductImage(string id);
        ProductImagehViewModel ListProductImage(int id);
    }
}