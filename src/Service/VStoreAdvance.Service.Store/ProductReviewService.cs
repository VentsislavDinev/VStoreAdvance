
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IRepository<Product> _product;

        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<ProductReview> _repo;

        private readonly IRepository<PromoCode> _category;

        private readonly IRepository<ProductCategory> _productCategory;
        private readonly IRepository<ProductReview> _productReview;
        private IRepository<Order> _order;

        public ProductReviewService( IRepository<Product> product, IRepository<ProductReview> productReview, IRepository<ProductReview> repo, IRepository<PromoCode> category, IRepository<ProductCategory> productCategory, IRepository<Order> order)
        {
            this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this._category = category ?? throw new ArgumentNullException(nameof(category));
            this._productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
            this._order = order ?? throw new ArgumentNullException(nameof(order));
            this._productReview = productReview ?? throw new ArgumentException(nameof(productReview));
            this._product = product ?? throw new ArgumentException(nameof(product)); 
        }

        public async Task<ProductReview> Create(string author, string comment, DateTime createdOn)
        {

            var createProductCategory = new ProductReview
            {
                UserName = author,
                Comment = comment,
                CreatedOn = createdOn,
            };

            await this._productReview.InsertAsync(createProductCategory);
           
            return createProductCategory;
        }

        public async Task<ProductReview> Update(string author, string comment, DateTime createdOn)
        {

            var createProductCategory = new ProductReview
            {
                UserName = author,
                Comment = comment,
                CreatedOn = createdOn,
            };

            await  this._productReview.UpdateAsync(createProductCategory);
           
            return createProductCategory;
        }

        public async Task<ProductReview> Delete(string author, string comment, DateTime createdOn)
        {

            var createProductCategory = new ProductReview
            {
                UserName = author,
                Comment = comment,
                CreatedOn = createdOn,
            };

           await  this._productReview.DeleteAsync(createProductCategory);
        
            return createProductCategory;
        }

        public IQueryable<ProductReview> GetAll()
        {
            return this._productReview.GetAll();
        }

        public IQueryable<ProductReview> GetById(int id)
        {
            return this._productReview.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<ProductReview> GetByName(string userName)
        {
            return this._productReview.GetAll().Where(x => x.UserName == userName);
        }
    }
}
