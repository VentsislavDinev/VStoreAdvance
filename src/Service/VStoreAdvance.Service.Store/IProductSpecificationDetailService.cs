using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductSpecificationDetailService : IApplicationService
    {
        Task<ProductSpecificationDetail> Create(string name, string description, int productId, int specificationId);
        Task<ProductSpecificationDetail> Delete(string name, string description, int productId, int specificationId);
        IQueryable<ProductSpecificationDetail> GetAll();
        IQueryable<ProductSpecificationDetail> GetById(int id);
        IQueryable<ProductSpecificationDetail> GetByName(string name);
        Task<ProductSpecificationDetail> Update(string name, string description, int productId, int specificationId);
    }
}