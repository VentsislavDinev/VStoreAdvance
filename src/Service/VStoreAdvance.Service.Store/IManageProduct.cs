
using HostingStore.ProductViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public interface IManageProduct
    {
        Task CreateProduct(ProductManageViewModel model, string file, ICollection<string> specification, ICollection<string> category, 
            ICollection<string> specificationDetail, ICollection<string> brands);
        Task DeleteProduct(ProductManageViewModel model, string file, int id, int categoryId);
        //Task CreateParentProduct(ProductManageViewModel model, string file, int id, int categoryId, int parentId);
        Task UpdateProduct(ProductManageViewModel model, string file, int id, int categoryId);
    }
}