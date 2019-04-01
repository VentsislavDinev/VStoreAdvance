using System.Collections.Generic;
using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductPromoHomeOrderService
    {
        Task<IList<ProductHomeServiceViewModel>> OrderProduct();
    }
}