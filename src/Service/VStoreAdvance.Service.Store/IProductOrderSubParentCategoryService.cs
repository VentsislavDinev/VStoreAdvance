using System.Collections.Generic;
using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductOrderSubParentCategoryService
    {
       Task<IList<ProductCategoryViewModel>> ListOrderProduct(int id);
       Task<IList<ProductCategoryViewModel>> OrderParrentProduct(int id);
       Task<IList<ProductCategoryViewModel>> OrderProduct(int id);
       Task<ProductCategoryViewModel> SingleOrderProduct(int id);
    }
}