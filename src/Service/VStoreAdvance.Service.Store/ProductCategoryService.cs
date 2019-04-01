
using Abp.Application.Services;
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductCategoryService : ApplicationService, IProductCategoryService
    {

        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<ProductReview> _repo;

        private readonly IRepository<PromoCode> _category;

        private readonly IRepository<ProductCategory> _productCategory;
        private readonly IRepository<Order> _order;

        public ProductCategoryService(  IRepository<ProductReview> repo, IRepository<PromoCode> category, IRepository<ProductCategory> productCategory, IRepository<Order> order)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _category = category ?? throw new ArgumentNullException(nameof(category));
            _productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
            _order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public async Task<ProductCategory> Create(string category)
        {
            ProductCategory createProductCategory = new ProductCategory
            {
                Category = category,
            };

            await  _productCategory.InsertAsync(createProductCategory);
            
            return createProductCategory;
        }

        public async Task<ProductCategory> CreateCategory(string category, int pid)
        {
            ProductCategory createProductCategory = new ProductCategory
            {
                Category = category,
            
            };

            await  _productCategory.InsertAsync (createProductCategory);
           
            return createProductCategory;
        }


        public async Task<ProductCategory> CreateParrentCategory(string category, int categoryId)
        {
            ProductCategory createProductCategory = new ProductCategory
            {
                Category = category,
               
            };

           await  _productCategory.InsertAsync(createProductCategory);
           
            return createProductCategory;
        }


        public async Task<ProductCategory> Update(string category)
        {
            ProductCategory createProductCategory = new ProductCategory
            {
                Category = category
            };

           await  _productCategory.UpdateAsync(createProductCategory);
           
            return createProductCategory;
        }


        public async Task<ProductCategory> Delete(string category)
        {
            ProductCategory createProductCategory = new ProductCategory
            {
                Category = category
            };

           await  _productCategory.DeleteAsync(createProductCategory);
           
            return createProductCategory;
        }

        public IQueryable<ProductCategory> GetAll()
        {
            return _productCategory.GetAll();
        }

        public IQueryable<ProductCategory> GetById(int id)
        {
            return _productCategory.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<ProductCategory> GetByName(string category)
        {
            return _productCategory.GetAll().Where(x => x.Category == category);
        }

    }
}
