using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductSpecificationService : IApplicationService
    {
        Task<ProductSpecification> Create(string name, string description, int productId);
        Task<ProductSpecification> Delete(string name, string description, int productId);
        IQueryable<ProductSpecification> GetAll();
        IQueryable<ProductSpecification> GetById(int id);
        IQueryable<ProductSpecification> GetByName(string name);
        Task<ProductSpecification> Update(string name, string description, int productId);
    }
}