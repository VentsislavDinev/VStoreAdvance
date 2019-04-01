using HostingStore.ProductViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public interface IOrderProductList
    {
        Task<ProductSearchViewModel> OrderProductByPraceRange(string name, string subCategory, string subParrentCategory, int id, double minPrice, double maxPrice);
        Task<ProductSearchViewModel> OrderProductByCategory(string name, string subCategory, string subParrentCategory, int id);
        Task<ProductSingleViewModel> SingleProduct(string name);
        Task<IList<ProductSingleViewModel>> ListBrandByProduct();
        Task<ProductSearchViewModel> OrderProductBySpecificationDetail(int id);
        Task<ProductSearchViewModel> OrderProduct(int id);
        Task<ProductSearchViewModel> OrderProductByCategory(int id, string category);
        Task<ProductSearchViewModel> OrderProductBySpecificationId(int id,  int specification);
        Task<ProductSearchViewModel> OrderProduct(int id, int categoryId);
        Task<ProductSearchViewModel> OrderProduct(int id, int categoryId, int brandId);
    }
}