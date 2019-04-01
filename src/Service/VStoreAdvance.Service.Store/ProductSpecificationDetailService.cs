
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductSpecificationDetailService : IProductSpecificationDetailService
    {
        private readonly IRepository<ProductSpecificationDetail> _productSpecification;
        private readonly string saveMediumImageLocation;

        public ProductSpecificationDetailService( IRepository<ProductSpecificationDetail> product)
        {
            _productSpecification = product ?? throw new ArgumentException(nameof(product));
        }


        public async Task<ProductSpecificationDetail> Create(string name, string description, int productId, int specificationId)
        {


             ProductSpecificationDetail newProduct = new ProductSpecificationDetail
            {
                Name = name,
                Description = description,                
                ProductSubCategoryId = productId,
                ProductSpecificationId = specificationId,
            };

            await  _productSpecification.InsertAsync(newProduct);
           
            return newProduct;
        }

        public async Task<ProductSpecificationDetail> Update(string name, string description, int productId, int specificationId)
        {

            ProductSpecificationDetail newProduct = new ProductSpecificationDetail
            {
                Name = name,
                Description = description,
                ProductId = productId,
                ProductSpecificationId = specificationId,
            };

            await  _productSpecification.UpdateAsync(newProduct);
           

            return newProduct;
        }


        public async Task<ProductSpecificationDetail> Delete(string name, string description, int productId, int specificationId)
        {

            ProductSpecificationDetail newProduct = new ProductSpecificationDetail
            {
                Name = name,
                Description = description,
                ProductId = productId,
                ProductSpecificationId = specificationId,
            };

           await   _productSpecification.DeleteAsync(newProduct);
           
            return newProduct;
        }


        public IQueryable<ProductSpecificationDetail> GetAll()
        {
            return _productSpecification.GetAll();
        }

        public IQueryable<ProductSpecificationDetail> GetById(int id)
        {
            return _productSpecification.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<ProductSpecificationDetail> GetByName(string name)
        {
            return _productSpecification.GetAll().Where(x => x.Name == name);
        }
    }
}
