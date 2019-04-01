using System.Collections.Generic;
using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductOrderCategorySubService
    {
        Task<ProductCategoryViewModel> GetProductCategorySubCategory(string id);
        Task<IList<ProductCategoryViewModel>> OrderParrentProduct(int id);
        Task<IList<ProductCategoryViewModel>> OrderProduct(int id);
        Task<ProductCategoryViewModel> GetProductCategorySubCategory(int id);
        Task<ProductCategoryViewModel> SingleOrderProduct(int id);
        Task<ProductCategoryViewModel> ListAllCategory(string category);

    }
}