using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductImageList
    {
        ProductImageListViewModel GetSingleProductImage(string id);
        ProductImagehViewModel ListProductImage(int id);
    }
}