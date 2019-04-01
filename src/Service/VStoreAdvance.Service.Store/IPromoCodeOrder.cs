using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IPromoCodeOrder : IApplicationService
    {
        PromoCodeListViewModel OrderPromoCode(int id);
        PromoCodeViewModel SinglePromoCode(string name);
    }
}