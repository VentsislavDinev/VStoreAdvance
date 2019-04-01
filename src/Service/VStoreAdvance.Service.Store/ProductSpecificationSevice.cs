
using Abp.Application.Services;
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
    public class ProductSpecificationService : ApplicationService, IProductSpecificationService
    {
        
        private readonly IRepository<ProductSpecification> _productSpecification;
        private readonly string saveMediumImageLocation;
        private readonly IRepository<ProductSubCategory> _productSubCategory;
        public ProductSpecificationService(IRepository<ProductSpecification> product, IRepository<ProductSubCategory> productSubCategory)
        {
           
            _productSpecification = product ?? throw new ArgumentException(nameof(product));

            _productSubCategory = productSubCategory ?? throw new ArgumentException(nameof(productSubCategory));
        }


        public async Task<ProductSpecification> Create(string name, string description, int productId)
        {


            ProductSpecification newProduct = new ProductSpecification
            {
                Name = name,
                Description = description,
                ProductSubCateoryId = productId,
            };

            await  _productSpecification.InsertAsync(newProduct);
           
            
            return newProduct;
        }

        public async Task<ProductSpecification> Update(string name, string description, int productId)
        {

            ProductSpecification newProduct = new ProductSpecification
            {
                Name = name,
                Description = description,
                ProductId = productId,
            };

           await  _productSpecification.UpdateAsync(newProduct);
            
            return newProduct;
        }


        public async Task<ProductSpecification> Delete(string name, string description, int productId)
        {

            ProductSpecification newProduct = new ProductSpecification
            {
                Name = name,
                Description = description,
                ProductId = productId,
            };

           await  _productSpecification.DeleteAsync(newProduct);
            
            return newProduct;
        }


        public IQueryable<ProductSpecification> GetAll()
        {
            return _productSpecification.GetAll();
        }

        public IQueryable<ProductSpecification> GetById(int id)
        {
            return _productSpecification.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<ProductSpecification> GetByName(string name)
        {
            return _productSpecification.GetAll().Where(x => x.Name == name);
        }
    }
}
