using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductSpecification : IApplicationService
    {
        Task CreateProduct(ProductSpecificationManageViewModel model, int productId);
        Task DeleteProduct(ProductSpecificationManageViewModel model, int productId);
        Task UpdateProduct(ProductSpecificationManageViewModel model, int productId);
    }
}