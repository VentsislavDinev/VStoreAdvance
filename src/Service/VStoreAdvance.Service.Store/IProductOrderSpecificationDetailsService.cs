using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductOrderSpecificationDetailsService : IApplicationService
    {
       Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationByProductName(int productId);
       Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationByProductName(int productId, int id);
       Task<IList<ProductSpecificationDetailManageViewModel>> SingleProductSpecificationByProductName(string productId);
       Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationBySpecificationId(int productId);
        IEnumerable<ProductSpecificationDetailManageViewModel> ListProductSpecificationDetail();
    }
}