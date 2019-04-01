using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductOrderSpecificationService : IProductOrderSpecificationService
    {
        private IProductSpecificationService _productSpecificationService;

        public ProductOrderSpecificationService(IProductSpecificationService productSpecificationService)
        {
            _productSpecificationService = productSpecificationService ?? throw new ArgumentNullException(nameof(productSpecificationService));
        }

        public async Task<IEnumerable<ProductSpecificationManageViewModel>> ListProductSpecificationByProductName(int productId)
        {

            List<ProductSpecificationManageViewModel> getProductSpecification = await _productSpecificationService.GetAll().Where(x => x.ProductId == productId)
                .Select(x => new ProductSpecificationManageViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Description = x.Description,
                }).ToListAsync();
            return getProductSpecification;

        }

        public async Task<IList<ProductSpecificationManageViewModel>> ProductSpecification(string category)
        {
            var item = Convert.ToInt32(category);
            List<ProductSpecificationManageViewModel> getProductSpecification = await _productSpecificationService.GetAll()
                     .Where(x => x.ProductSubCateoryId == item
                     )
            .Select(x => new ProductSpecificationManageViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
            return getProductSpecification;

        }
        public async Task<IList<ProductSpecificationManageViewModel>> ProductSpecification()
        {
            List<ProductSpecificationManageViewModel> getProductSpecification = await _productSpecificationService.GetAll()
                     .Where(x => (x.ProductId == 0 | x.ProductId == null)
                     )
            .Select(x => new ProductSpecificationManageViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
            return getProductSpecification;

        }

        public async Task<ProductSpecificationManageViewModel> SingleProductSpecificationByProductName(string productId)
        {

            ProductSpecificationManageViewModel getProductSpecification = await _productSpecificationService.GetAll().Where(x => x.Product.Name == productId)
                .Select(x => new ProductSpecificationManageViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                }).FirstOrDefaultAsync();
            return getProductSpecification;

        }


        public async Task<int> SingleProductSpecificationBySpecId(int productId)
        {

            int getProductSpecification = await _productSpecificationService.GetAll().Where(x => x.Id == productId)
                .Select(x => x.Product.Id).FirstOrDefaultAsync();
            return getProductSpecification;

        }
    }
}
