using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManagePromoCode : IApplicationService
    {
        Task CreateProduct(PromoCodeManageViewModel model);
        Task DeleteProduct(PromoCodeManageViewModel model);
        Task UpdateProduct(PromoCodeManageViewModel model);
    }
}