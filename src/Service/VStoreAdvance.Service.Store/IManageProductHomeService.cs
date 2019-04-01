using System.Threading.Tasks;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IManageProductHomeService
    {
        Task Create(ProductHomeServiceViewModel model);
        Task DeleteProduct(ProductHomeServiceViewModel model);
        Task Update(ProductHomeServiceViewModel model);
    }
}