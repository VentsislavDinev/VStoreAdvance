using System.Collections.Generic;
using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductOrderSpecificationService
    {
        Task<IEnumerable<ProductSpecificationManageViewModel>> ListProductSpecificationByProductName(int productId);
        Task<IList<ProductSpecificationManageViewModel>> ProductSpecification(string category);
        Task<IList<ProductSpecificationManageViewModel>> ProductSpecification();
        Task<int> SingleProductSpecificationBySpecId(int productId);
        Task<ProductSpecificationManageViewModel> SingleProductSpecificationByProductName(string productId);
    }
}