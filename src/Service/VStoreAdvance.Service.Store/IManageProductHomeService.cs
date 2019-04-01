using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductHomeService : IApplicationService
    {
        Task Create(ProductHomeServiceViewModel model);
        Task DeleteProduct(ProductHomeServiceViewModel model);
        Task Update(ProductHomeServiceViewModel model);
    }
}