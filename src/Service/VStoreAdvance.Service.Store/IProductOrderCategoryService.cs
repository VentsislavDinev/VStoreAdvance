using HostingStore.ProductViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public interface IProductOrderCategoryService
    {
       Task<IList<ProductCategoryViewModel>> ListAllCategoryWithSubCategory();
       Task<ProductCategoryViewModel> ListAllCategoryWithSubCategory(string category);
       Task<ProductCategoryViewModel> SingleOrderProduct(int id);
       Task<IList<ProductCategoryViewModel>> OrderProduct(int id);
       Task<IList<ProductCategoryViewModel>> ListAllCategoryByProductId(int id);
       Task<IList<ProductCategoryViewModel>> ListOrderProduct(int? id); 
    }
}