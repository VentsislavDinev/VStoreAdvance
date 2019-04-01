using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductOrderSpecificationService : IApplicationService
    {
        Task<IEnumerable<ProductSpecificationManageViewModel>> ListProductSpecificationByProductName(int productId);
        Task<IList<ProductSpecificationManageViewModel>> ProductSpecification(string category);
         IList<ProductSpecificationManageViewModel> ProductSpecification();
        Task<int> SingleProductSpecificationBySpecId(int productId);
        Task<ProductSpecificationManageViewModel> SingleProductSpecificationByProductName(string productId);
    }
}