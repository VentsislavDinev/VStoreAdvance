using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManagePromoCode
    {
        Task CreateProduct(PromoCodeManageViewModel model);
        Task DeleteProduct(PromoCodeManageViewModel model);
        Task UpdateProduct(PromoCodeManageViewModel model);
    }
}