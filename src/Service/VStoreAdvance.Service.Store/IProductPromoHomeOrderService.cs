using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductPromoHomeOrderService : IApplicationService
    {
        IList<ProductHomeServiceViewModel> OrderProduct();
    }
}