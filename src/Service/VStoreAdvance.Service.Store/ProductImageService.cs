
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductImageService : IProductImageService
    {


        private readonly IRepository<ProductImage> _product;



        public ProductImageService(IRepository<ProductImage> promoImage)
        {
            _product = promoImage ?? throw new ArgumentException(nameof(promoImage));
        }


        public async Task<ProductImage> Create(string code, DateTime createdOn, int productId)
        {
            ProductImage newProduct = new ProductImage
            {
                File = code,
                CreatedOn = createdOn,
                ProductId = productId,
            };

            await _product.InsertAsync(newProduct);

            return newProduct;
        }



        public async Task<ProductImage> Update(string code, DateTime createdOn, int productId)
        {
            ProductImage newProduct = new ProductImage
            {
                File = code,
                CreatedOn = createdOn,
                ProductId = productId,
            };

            await _product.InsertAsync(newProduct);

            return newProduct;
        }



        public async Task<ProductImage> Delete(string code, DateTime createdOn, int productId)
        {
            ProductImage newProduct = new ProductImage
            {
                File = code,
                CreatedOn = createdOn,
                ProductId = productId,
            };

            await _product.DeleteAsync(newProduct);

            return newProduct;
        }

        public IQueryable<ProductImage> GetAll()
        {
            return this._product.GetAll();
        }

        public IQueryable<ProductImage> GetById(int id)
        {
            return this._product.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<ProductImage> GetByProductId(int productId)
        {
            return this._product.GetAll().Where(x => x.ProductId == productId);

        }
    }
}