using System.Linq;
using System.Threading.Tasks;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductPromoHomeService
    {
        Task<ProductPromoHome> Create(string name, string desc, string avatar, double price);
        Task<ProductPromoHome> Delete(string name, string desc, string avatar, double price);
        IQueryable<ProductPromoHome> GetAll();
        IQueryable<ProductPromoHome> GetById(int id);
        IQueryable<ProductPromoHome> GetByName(string code);
        Task<ProductPromoHome> Update(string name, string desc, string avatar, double price);
    }
}