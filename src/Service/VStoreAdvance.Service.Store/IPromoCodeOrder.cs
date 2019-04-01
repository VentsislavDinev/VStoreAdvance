using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IPromoCodeOrder
    {
        PromoCodeListViewModel OrderPromoCode(int id);
        PromoCodeViewModel SinglePromoCode(string name);
    }
}