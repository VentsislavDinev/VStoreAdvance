using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductOrderCategorySubService : ApplicationService, IProductOrderCategorySubService
    {
        private const int pageNumber = 100;
        private readonly IProductCategorySubService _productCategory;
        public ProductOrderCategorySubService(IProductCategorySubService productCategory)
        {
            _productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
        }

        public async Task<IList<ProductCategoryViewModel>> OrderProduct(int id)
        {
            int page = id;

            int allItemCount = _productCategory.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            List<ProductCategoryViewModel> getAll = await  _productCategory.GetAll()
                .Where(x => x.ProductCategoryID == id & (x.ProductID != null | x.ProductID != 0))
                .OrderByDescending(x => x.Category)
                //.Skip(itemToSkipFromDb)
                //.Take(pageNumber)
                .Select(x => new ProductCategoryViewModel
                {
                    CategoryId = x.ProductCategory.Id,
                    Id = x.Id,
                    Category = x.Category,
                }).ToListAsync();

            return getAll;
        }

        public async Task<IList<ProductCategoryViewModel>> OrderParrentProduct(int id)
        {
            int page = id;

            int allItemCount = _productCategory.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            List<ProductCategoryViewModel> getAll =await  _productCategory.GetAll()
                 .Where(x => x.ProductCategoryID == id)
                .OrderByDescending(x => x.Category)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCategoryViewModel
                {
                    CategoryId = x.ProductCategory.Id,
                    Id = x.Id,
                    Category = x.Category,
                }).ToListAsync();

            return getAll;
        }

        public async Task<ProductCategoryViewModel> GetProductCategorySubCategory(int id)
        {

            var getAll = await  _productCategory.GetAll()

                .Where(x => x.Id == id)
                .Select(x => new ProductCategoryViewModel
                {
                    CategoryId = x.ProductCategory.Id,
                    Id = x.Id,
                    Category = x.Category,
                }).FirstOrDefaultAsync();
            return getAll;
        }
        public  async Task<ProductCategoryViewModel> GetProductCategorySubCategory(string id)
        {

            var getAll =await  _productCategory.GetAll()

                .Where(x => x.Category == id)
                .Select(x => new ProductCategoryViewModel
                {
                    CategoryId = x.ProductCategory.Id,
                    Id = x.Id,
                    Category = x.Category,
                }).FirstOrDefaultAsync();
            return getAll;
        }


        public async Task<ProductCategoryViewModel> SingleOrderProduct(int id)
        {
            int page = id;

            int allItemCount = _productCategory.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            ProductCategoryViewModel getAll = await  _productCategory.GetAll()

                .Where(x => x.ProductCategoryID == id)
                .Select(x => new ProductCategoryViewModel
                {
                    CategoryId = x.ProductCategory.Id,
                    Id = x.Id,
                    Category = x.Category,
                }).FirstOrDefaultAsync();

            return getAll;
        }
        public async Task<IList<ProductCategoryViewModel>> ListOrderProduct(int id)
        {
            int page = id;

            int allItemCount = _productCategory.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            List<ProductCategoryViewModel> getAll = await  _productCategory.GetAll()
                .Where(x => x.ProductCategoryID == id)
                .OrderByDescending(x => x.Category)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCategoryViewModel
                {
                    CategoryId = x.ProductCategoryID,
                    Id = x.Id,
                    Category = x.Category,
                }).ToListAsync();

                return getAll;
        }
        

        //public async Task<IProductOrderCategorySubService> ListOrderProduct(int id)
        //{
        //    var getAll =  await  _productCategory.GetAll()

        //              .Where(x => x.Id == id)
        //              .Select(x => new ProductCategoryViewModel
        //              {
        //                  CategoryId = x.ProductCategory.Id,
        //                  Id = x.Id,
        //                  Category = x.Category,
        //              }).FirstOrDefaultAsync();
        //    return getAll;
        //}

        public async Task<ProductCategoryViewModel> ListAllCategory(string category)
        {

            var getAll = await _productCategory.GetAll()

                .Where(x => x.Category == category)
                .Select(x => new ProductCategoryViewModel
                {
                    CategoryId = x.ProductCategory.Id,
                    Id = x.Id,
                    Category = x.Category,
                }).FirstOrDefaultAsync();
            return getAll;
        }
    }
}
