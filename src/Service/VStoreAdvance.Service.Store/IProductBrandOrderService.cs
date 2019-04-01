using System.Collections.Generic;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductBrandOrderService
    {
        List<ProductBrandViewModel> GetAll();
        List<ProductBrandViewModel> GetTopBrand();
        ProductBrandViewModel GetBrandByName(string category);
    }
}