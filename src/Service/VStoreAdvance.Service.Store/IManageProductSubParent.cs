using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductSubParent : IApplicationService
    {
        Task CreateProduct(ProductCategoryViewModel model, string id);
        Task DeleteProduct(ProductCategoryViewModel model, string id);
        Task UpdateProduct(ProductCategoryViewModel model, string id);
    }
}