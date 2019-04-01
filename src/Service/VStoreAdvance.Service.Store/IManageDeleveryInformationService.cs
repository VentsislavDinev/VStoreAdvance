using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public interface IManageDeleveryInformationService : IApplicationService
    {
        Task CreateProduct(DeleveryInformationViewModel model);
        Task DeleteProduct(DeleveryInformationViewModel model);
        Task UpdateProduct(DeleveryInformationViewModel model);
    }
}