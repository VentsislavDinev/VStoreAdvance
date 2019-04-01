using System.Collections.Generic;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductBrandOrderService : IApplicationService
    {
        List<ProductBrandViewModel> GetAll();
        List<ProductBrandViewModel> GetTopBrand();
        ProductBrandViewModel GetBrandByName(string category);
    }
}