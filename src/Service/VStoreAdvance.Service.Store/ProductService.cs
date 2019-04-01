
using Abp.Application.Services;
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VStoreAdvance.Data.EntityFramework;

namespace HostingStore.ProductService
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly VStoreAdvanceDbContext dbContext = new VStoreAdvanceDbContext();
       

        private readonly IRepository<Product> _product;
     
        private readonly IRepository<PromoCode> _category;

        private readonly IRepository<ProductCategory> _productCategory;
        private readonly IRepository<ProductSubCategory> _productSubCategory;
        private readonly IRepository<ProductSpecification> _productSpecification;
        private readonly IRepository<ProductSpecificationDetail> _productSpecificationDetail;
        private readonly IRepository<ProductBrand> _productBrand;

        private readonly IRepository<Order> _order;

        public ProductService(
            IRepository<Product> product,
            IRepository<ProductSubCategory> productSubCategory,
            IRepository<ProductSpecification> productSpecification,
            IRepository<ProductSpecificationDetail> productSpecificationDetail,
          
            IRepository<PromoCode> category,
            IRepository<ProductCategory> productCategory,
            IRepository<Order> order,
            IRepository<ProductBrand> productBrand)
        {
            _category = category ?? throw new ArgumentNullException(nameof(category));
            _productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
            _order = order ?? throw new ArgumentNullException(nameof(order));
            _product = product ?? throw new ArgumentException(nameof(product));
            _productSubCategory = productSubCategory ?? throw new ArgumentException(nameof(productSubCategory));
            _productSpecificationDetail = productSpecificationDetail ?? throw new ArgumentException(nameof(productSpecificationDetail));
            _productSpecification = productSpecification ?? throw new ArgumentException(nameof(productSpecification));
            _productBrand = productBrand ?? throw new ArgumentException(nameof(productBrand));
        }

        public async Task<Product> Create(string name, string description,
            decimal? realPrice, decimal price, DateTime? createdOn,
            DateTime? startPromo, TimeSpan? endPromo, decimal? promoPrice, string file,
             ICollection<string> specification, ICollection<string> category, ICollection<string> specificationDetail, ICollection<string> brand)
        {


            Product newProduct = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                CreatedOn = DateTime.Now,
                StartPromoPrice = startPromo,
                EndPromoPrice = endPromo,
                PromoPrice = promoPrice,
                RealPrice = realPrice,
                Avatar = file,
                //ProductCategoryId = categoryId,
                //ProductSubCategoryId = id,

            };
            _product.InsertAsync(newProduct);
          
            //list data 
            foreach (string item in category)
            {
                int itemId = Convert.ToInt32(item);

                ProductSubCategory getSpecification = _productSubCategory.GetAll().SingleOrDefault(x => x.Id == itemId);

                ProductSubCategory newSubCategory = new ProductSubCategory
                {
                    Category = getSpecification.Category,
                    ProductID = newProduct.Id,
                    ProductSpecificationId = getSpecification.ProductSpecificationId,
                    ProductCategoryID = getSpecification.ProductCategoryID,
                };
                newProduct.ProductSubCategoryId = getSpecification.Id;
                await  _productSubCategory.InsertAsync(newSubCategory);
                newProduct.ProductSubCategory.Add(newSubCategory);
               


            }

            foreach (string item in specificationDetail)
            {
                int itemid = Convert.ToInt32(item);
                ProductSpecificationDetail getSpecDetail = _productSpecificationDetail.GetAll().SingleOrDefault(x => x.Id == itemid);
                ProductSpecificationDetail newSpecDetail = new ProductSpecificationDetail
                {
                    Name = getSpecDetail.Name,
                    Description = getSpecDetail.Description,
                    ProductId = newProduct.Id,
                    ProductSpecificationId = getSpecDetail.ProductSpecificationId,
                };
                newProduct.ProductSpecificationDetailId = getSpecDetail.Id;
               await  _productSpecificationDetail.InsertAsync(newSpecDetail);
                newProduct.ProductSpecificationDetail.Add(newSpecDetail);
                
            }

            foreach (string item in brand)
            {
                int itemId = Convert.ToInt32(item);

                ProductBrand getSpecification = _productBrand.GetAll().SingleOrDefault(x => x.Id == itemId);

                ProductBrand newSubCategory = new ProductBrand
                {
                    Name = getSpecification.Name,
                    ProductId = newProduct.Id,
                    Image = getSpecification.Image,
                    Description = getSpecification.Description,

                };
                newProduct.ProductBrandId = getSpecification.Id;
                await _productBrand.InsertAsync(newSubCategory);
                newProduct.ProductBrand.Add(newSubCategory);
                

            }
           
            return newProduct;
        }



        //public async Task<Product> ParentCreate(string name, string description, decimal? realPrice, decimal price,
        //    DateTime createdOn, DateTime? startPromo, TimeSpan? endPromo, decimal? promoPrice, string file, int id, int categoryId,
        //    int subCategory, string brand)
        //{


        //    Product newProduct = new Product
        //    {
        //        Name = name,
        //        Description = description,
        //        Price = price,
        //        CreatedOn = DateTime.Now,
        //        StartPromoPrice = startPromo,
        //        EndPromoPrice = endPromo,
        //        PromoPrice = promoPrice,
        //        RealPrice = realPrice,
        //        Avatar = file,

        //    };

        //    _product.Add(newProduct);
        //    try
        //    {
        //        await _product.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return newProduct;
        //}


        public async Task<Product> Update(string name, string description,
            decimal? realPrice, decimal price, DateTime? createdOn, DateTime? startPromo, TimeSpan? endPromo,
            decimal? promoPrice, string file, int id, int categoryId, string brand)
        {

            Product newProduct = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                CreatedOn = createdOn,
                StartPromoPrice = startPromo,
                EndPromoPrice = endPromo,
                PromoPrice = promoPrice,
                RealPrice = realPrice,
                Avatar = file,
                ProductCategoryId = categoryId,
                ProductSubCategoryId = id,

            };

            await  _product.UpdateAsync(newProduct);
           
            return newProduct;
        }


        public async Task<Product> Delete(string name, string description, decimal? realPrice,
            decimal price, DateTime? createdOn, DateTime? startPromo, TimeSpan? endPromo,
            decimal? promoPrice, string file, int id, int categoryId, string brand)
        {

            Product newProduct = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                CreatedOn = createdOn,
                StartPromoPrice = startPromo,
                EndPromoPrice = endPromo,
                PromoPrice = promoPrice,
                RealPrice = realPrice,
                Avatar = file,
                ProductCategoryId = categoryId,
                ProductSubCategoryId = id,

            };

           await  _product.DeleteAsync(newProduct);
            
            return newProduct;
        }

        public IQueryable<Product> GetAll()
        {
            return _product.GetAll();
        }

        public IQueryable<Product> GetById(int id)
        {
            return _product.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<Product> GetByName(string name)
        {
            return _product.GetAll().Where(x => x.Name == name);
        }

        public Task<Product> ParentCreate(string name, string description, double? realPrice, double price, DateTime createdOn, DateTime? startPromo, TimeSpan? endPromo, double? promoPrice, string file, int id, int categoryId, string brand)
        {
            throw new NotImplementedException();
        }
    }
}
