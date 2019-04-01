using HostingStore.ProductViewModel;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public interface IManageProductBrand
    {
        Task Create(ProductBrandViewModel model);
        Task Delete(ProductBrandViewModel model);
        Task Update(ProductBrandViewModel model);
    }
}