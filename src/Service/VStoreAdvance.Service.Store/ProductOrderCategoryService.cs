using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductOrderCategoryService : ApplicationService, IProductOrderCategoryService
    {
        private const int pageNumber = 100;
        private readonly IProductCategoryService _productCategory;
        private readonly IProductCategorySubService _productSubCategory;
        public ProductOrderCategoryService( IProductCategoryService productCategory, IProductCategorySubService productCategorySub)
        {

            _productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
            _productSubCategory = productCategorySub ?? throw new ArgumentNullException(nameof(productCategorySub));
        }

        public async Task<IList<ProductCategoryViewModel>> OrderProduct(int id)
        {
            int page = id;

            int allItemCount = _productCategory.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            var getAll = await  _productCategory.GetAll()
             
                .OrderByDescending(x => x.Category)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                }).ToListAsync();
          
            return getAll;
        }
        public IList<ProductCategoryViewModel> ListAllCategoryWithSubCategory()
        {
            var getAll =  _productCategory.GetAll()
                
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                }).ToList();
            return getAll;
        }

        public async Task<ProductCategoryViewModel> ListAllCategoryWithSubCategory(string category)
        {
            var getAll = await _productCategory.GetAll()
                .Where(x=>x.Category == category)
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                }).FirstOrDefaultAsync();
            return getAll;
        }

        public async Task<IList<ProductCategoryViewModel>> ListAllCategoryByProductId(int id)
        {
            var getAll = await _productCategory.GetAll()
                .Where(x=>x.ProductID == id)
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                }).ToListAsync();
            return getAll;
        }


        public async Task< IList<ProductCategoryViewModel>> OrderParrentProduct(int id)
        {
            int page = id;

            int allItemCount = await _productCategory.GetAll().CountAsync();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            var getAll =  await  _productCategory.GetAll()
             
                .OrderByDescending(x => x.Category)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                }).ToListAsync();

            return getAll;
        }
        public async Task<ProductCategoryViewModel> SingleOrderProduct(int id)
        {
          
            var getAll = await _productCategory.GetAll()

                .Where(x=>x.Id== id)
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                }).FirstOrDefaultAsync();

            return getAll;
        }


        public async Task<IList<ProductCategoryViewModel>> ListOrderProduct(int? id)
        {
            int? page = id;

            int allItemCount = await _productCategory.GetAll().CountAsync();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            var getAll = await _productCategory.GetAll()

                .OrderByDescending(x => x.Category)
                //.Skip(itemToSkipFromDb)
                //.Take(pageNumber)
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                    
                }).ToListAsync();

            return getAll;
        }

        public async Task<IList<ProductCategoryViewModel>> ListOrderProductCategory(int id)
        {
            int page = id;

            int allItemCount = await _productSubCategory.GetAll().CountAsync();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            var getAll = await _productSubCategory.GetAll()
                .Where(x=>x.ProductCategoryID == id & 
                        (x.ProductID == 0 || x.ProductID == null))
                .OrderByDescending(x => x.Category)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                }).ToListAsync();

            return getAll;
        }

        public IList<ProductCategoryViewModel> ListOrderProductCategoryNotAsync(int id)
        {
            var getAll =  _productSubCategory.GetAll()
                .Where(x => x.ProductCategoryID == id &
                        (x.ProductID == 0 || x.ProductID == null))
                
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Category = x.Category,
                }).ToList();

            return getAll;
        }
    }
}
