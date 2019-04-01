using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductSpecificationDetailService
    {
        Task CreateProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId);
        Task DeleteProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId);
        Task UpdateProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId);
    }
}