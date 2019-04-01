using System.Collections.Generic;
using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductOrderSpecificationDetailsService
    {
       Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationByProductName(int productId);
       Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationByProductName(int productId, int id);
       Task<IList<ProductSpecificationDetailManageViewModel>> SingleProductSpecificationByProductName(string productId);
       Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationBySpecificationId(int productId);
       Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationDetail();
    }
}