using Abp.Application.Services;
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductCategorySubService : ApplicationService, IProductCategorySubService
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<ProductSubCategory> _productCategorySub;

        public ProductCategorySubService(IRepository<ProductSubCategory> productCategorySub)
        {
            _productCategorySub = productCategorySub ?? throw new ArgumentNullException(nameof(productCategorySub));
        }


        public async Task<ProductSubCategory> Create(string category, int id)
        {
            ProductSubCategory createProductCategory = new ProductSubCategory
            {
                Category = category,
                ProductCategoryID = id,
            };

           await  _productCategorySub.InsertAsync(createProductCategory);
           
            return createProductCategory;
        }


        public async Task<ProductSubCategory> Update(string category, int id)
        {
            ProductSubCategory createProductCategory = new ProductSubCategory
            {
                Category = category,
                ProductCategoryID = id,
            };

          await   _productCategorySub.UpdateAsync(createProductCategory);
            
            return createProductCategory;
        }


        public async Task<ProductSubCategory> Delete(string category, int id)
        {
            ProductSubCategory createProductCategory = new ProductSubCategory
            {
                Category = category,
                ProductCategoryID = id,
            };

           await  _productCategorySub.DeleteAsync(createProductCategory);
         
            return createProductCategory;
        }

        public IQueryable<ProductSubCategory> GetAll()
        {
            return _productCategorySub.GetAll();
        }

        public IQueryable<ProductSubCategory> GetById(int id)
        {
            return _productCategorySub.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<ProductSubCategory> GetByName(string category)
        {
            return _productCategorySub.GetAll().Where(x => x.Category == category);
        }
    }
}
