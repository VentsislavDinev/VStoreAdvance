using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductSpecificationDetailService : IApplicationService
    {
        Task CreateProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId);
        Task DeleteProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId);
        Task UpdateProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId);
    }
}