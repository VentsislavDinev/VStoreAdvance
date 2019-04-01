using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductSpecification
    {
        Task CreateProduct(ProductSpecificationManageViewModel model, int productId);
        Task DeleteProduct(ProductSpecificationManageViewModel model, int productId);
        Task UpdateProduct(ProductSpecificationManageViewModel model, int productId);
    }
}