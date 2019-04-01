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
    public class ProductOrderSubParentCategoryService : ApplicationService, IProductOrderSubParentCategoryService
    {
        private const int pageNumber = 100;
        private readonly IProductCategorySubService _productCategory;
        public ProductOrderSubParentCategoryService(IProductCategorySubService productCategory)
        {
            _productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
        }

        public async Task<IList<ProductCategoryViewModel>> OrderProduct(int id)
        {
            int page = id;

            int allItemCount = _productCategory.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            List<ProductCategoryViewModel> getAll =await _productCategory.GetAll()
                .Where(x => x.ProductID == id)
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

        public async Task<IList<ProductCategoryViewModel>> OrderParrentProduct(int id)
        {
            int page = id;

            int allItemCount = _productCategory.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            List<ProductCategoryViewModel> getAll = await _productCategory.GetAll()
           
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
            int page = id;

            int allItemCount = _productCategory.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
           ProductCategoryViewModel getAll = await _productCategory.GetAll()

         
                .Select(x => new ProductCategoryViewModel
                {
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
            try
            {
                List<ProductCategoryViewModel> getAll = await _productCategory.GetById(id)
         
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
            catch (Exception ex)
            {

                throw new ArgumentNullException(ex.Message);
            }
     
        }
    }
}
