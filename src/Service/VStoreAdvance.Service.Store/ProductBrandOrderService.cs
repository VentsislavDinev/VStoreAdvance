using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductBrandOrderService : ApplicationService, IProductBrandOrderService
    {
        private readonly IProductBrandService _productBrand;

        public ProductBrandOrderService(IProductBrandService productBrand)
        {
            _productBrand = productBrand ?? throw new ArgumentNullException(nameof(productBrand));
        }

        public List<ProductBrandViewModel> GetAll()
        {
            var getAll = _productBrand.GetAll().Select(x => new ProductBrandViewModel
            {
                Name = x.Name,
                Description = x.Description, 
                Image = x.Image
            }).ToList();

            return getAll;
        }

        public ProductBrandViewModel GetBrandByName(string category)
        {
            var getAll = _productBrand.GetAll()
              .Where(x => (x.ProductId == 0 || x.ProductId == null) & (x.Name.Contains(category)  || x.Name != null))
              .Select(x => new ProductBrandViewModel
              {
                  Id = x.Id,
                  Name = x.Name,
                  Description = x.Description,
                  Image = x.Image
              }).FirstOrDefault();
            return getAll;

        }

        public List<ProductBrandViewModel> GetTopBrand()
        {
            return _productBrand.GetAll()
                .Where(x=>x.ProductId == 0 || x.ProductId == null)
                .Select(x => new ProductBrandViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            }).ToList();

        }
    }
}
