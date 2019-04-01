using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductOrderImageService : ApplicationService, IProductOrderImageService
    {
        private IProductImageService _productImage;

        public ProductOrderImageService(IProductImageService productImage)
        {
            _productImage = productImage ?? throw new ArgumentNullException(nameof(productImage));
        }

        public async Task<IEnumerable<ProductImageListViewModel>> ListProductImageByProductName(int productId, int id)
        {

           var  getProductSpecification = await _productImage.GetAll().Where(x => x.ProductId == productId)
                .Select(x => new ProductImageListViewModel
                {
                      Avatar = x.File,
                      ProductId = x.ProductId,
                }).ToListAsync();
            return getProductSpecification;

        }

        public async Task<IEnumerable<ProductImageListViewModel>> ListProductImageByProductName(int productId)
        {
            List<ProductImageListViewModel> getProductSpecification = await  _productImage.GetAll().Where(x => x.ProductId == productId)
                  .Select(x => new ProductImageListViewModel
                  {
                      Avatar = x.File,
                      ProductId = x.ProductId,
                  }).ToListAsync();
            return getProductSpecification;
        }

        public async Task<IEnumerable<ProductImageListViewModel>> ListProductImage()
        {

            List<ProductImageListViewModel> getProductSpecification = await  _productImage.GetAll()
                .Select(x => new ProductImageListViewModel
                {
                    Avatar = x.File,
                    ProductId = x.ProductId,
                }).ToListAsync();
            return getProductSpecification;

        }



        public async Task<IList<ProductImageListViewModel>> SingleProductImageByProductName(string productId)
        {

            List<ProductImageListViewModel> getProductSpecification = await  _productImage.GetAll().Where(x => x.Product.Name == productId)
                .Select(x => new ProductImageListViewModel
                {
                    Avatar = x.File,
                    ProductId = x.ProductId,
                }).ToListAsync();
            return getProductSpecification;

        }
    }
}
