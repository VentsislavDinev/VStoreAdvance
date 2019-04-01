
using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VStoreAdvance.Data.EntityFramework;

namespace HostingStore.ProductService
{
    public class OrderProductList : ApplicationService, IOrderProductList
    {
        private const int pageNumber = 100;
        private IProductService _productService;
        private readonly IProductCategorySubService _productCategory;
        private readonly IProductBrandService _productBrandService;
        private readonly IProductImageService _productImage;
        private readonly IProductReviewService _productReview;
        private readonly IProductOrderSpecificationService _productSpecificationService;
        private readonly IProductOrderSpecificationDetailsService _productOrderSpecificationDetailsService;
        VStoreAdvanceDbContext dbContext = new VStoreAdvanceDbContext();
        public OrderProductList(IProductService productService, IProductCategorySubService productCategory,
            IProductImageService productImage, IProductReviewService productReview, 
            IProductOrderSpecificationService productSpecificationService,
            IProductOrderSpecificationDetailsService productOrderSpecificationDetailsService, IProductBrandService productBrandService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
            _productImage = productImage ?? throw new ArgumentNullException(nameof(productImage));
            _productReview = productReview ?? throw new ArgumentNullException(nameof(productReview));
            _productSpecificationService = productSpecificationService ?? throw new ArgumentNullException(nameof(productSpecificationService));
            _productOrderSpecificationDetailsService = productOrderSpecificationDetailsService ?? throw new ArgumentNullException(nameof(productOrderSpecificationDetailsService));
            _productBrandService = productBrandService ?? throw new ArgumentNullException(nameof(productBrandService));
         }


        public async Task<ProductSearchViewModel> OrderProductBySpecificationDetail(int id)
        {
            int page = id;

            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;


            
            List<ProductCatalogViewModel> getAll = await _productService.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCatalogViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Avatar = x.Avatar,
                }).ToListAsync();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;
        }


        public  async Task<ProductSearchViewModel> OrderProduct(int id, string category, string Brand)
        {

            int page = id;

            var zipData = new List<ProductCatalogViewModel>();

            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;

            var getAll = await (from app in dbContext.Products
                          join service in dbContext.ProductBrands on app.ProductBrandId equals service.Id
                          join product in dbContext.ProductCategories on app.ProductCategoryId equals product.Id
                          
                          where service.Name == "VDinev1234"
                          where product.Category == "Компютри"
                          select new ProductCatalogViewModel
                          {
                              Id = app.Id,
                              Keyword = app.Keyword,

                              Name = app.Name,
                              Brand = service.Name,
                              Category = product.Category,
                              //ProductName = product.Category,
                               Avatar = app.Avatar,
                              Price = app.Price
                              //ProductProductId = product.Product.Name,
                          }).OrderByDescending(x => x.CreatedOn)
                          .Skip(itemToSkipFromDb)
                          .Take(pageNumber)
                          .ToListAsync();

            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;

        }



        public async Task<ProductSearchViewModel> OrderProduct(int id, int categoryId)
        {
            int page = id;

            var zipData = new List<ProductCatalogViewModel>();

            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;




            //var test = _productService.GetAll().Join(dbContext.ProductBrands, entryPoint => entryPoint.Id)

            List<ProductCatalogViewModel> getAll = await _productService.GetAll()
                .Where(x=>x.ProductSubCategoryId == categoryId)
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCatalogViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Avatar = x.Avatar,
                }).ToListAsync();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;
        }


        public ProductSearchViewModel OrderProduct(int id)
        {
            int page = id;

            var zipData = new List<ProductCatalogViewModel>();

            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            
          
            //var test = _productService.GetAll().Join(dbContext.ProductBrands, entryPoint => entryPoint.Id)

            List<ProductCatalogViewModel> getAll =  _productService.GetAll()
           
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCatalogViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Avatar = x.Avatar,
                }).ToList();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;
        }
        public async Task<ProductSearchViewModel> OrderProducts(int id)
        {
            int page = id;

            var zipData = new List<ProductCatalogViewModel>();

            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
      
            List<ProductCatalogViewModel> getAll = await _productService.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCatalogViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Avatar = x.Avatar,
                }).ToListAsync();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;
        }


        public IList<ProductSingleViewModel> ListBrandByProduct()
        {
            IList<ProductSingleViewModel> getAll =  _productService.GetAll()

               .Select(x => new ProductSingleViewModel
               {
                   
               })
               .ToList();
            return getAll;
        }


        public async Task<ProductSingleViewModel> SingleProduct(string name)
        {
            ProductSingleViewModel getAll = await _productService.GetById(Convert.ToInt32(name))
               .Select(x => new ProductSingleViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   Price = x.Price,
                   Avatar = x.Avatar,
                   EndPromoPrice = x.EndPromoPrice,
                   PromoPrice = x.PromoPrice,
                   RealPrice = x.RealPrice,
                   StartPromoPrice = x.StartPromoPrice,
                   
               })
               .SingleOrDefaultAsync();
            return getAll;
        }

        public async Task<ProductSearchViewModel> OrderProductByCategory(string name, string subCategory, string subParrentCategory, int id)
        {
            int page = id;
            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;

            List<ProductCatalogViewModel> getAll = await _productService.GetAll()
                    .OrderByDescending(q => q.CreatedOn)
                    .ThenByDescending(q => q.PromoPrice)
                    .ThenByDescending(q => q.StartPromoPrice)
                    .Skip(itemToSkipFromDb)
                    .Take(pageNumber)
                    .Select(x => new ProductCatalogViewModel
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price,
                        Avatar = x.Avatar,
                    })
                    .ToListAsync();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                ProductFilter = getAll,
            };

            return searchEmpty;
        }

        public async Task<ProductSearchViewModel> OrderProductByPraceRange(string name, string subCategory, string subParrentCategory, int id, double minPrice, double maxPrice)
        {
            int page = id;
            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;

            List<ProductCatalogViewModel> getAll = await _productService.GetAll()
                    .OrderByDescending(q => q.CreatedOn)

                    .ThenByDescending(q => q.PromoPrice)
                    .ThenByDescending(q => q.StartPromoPrice)
                    .Skip(itemToSkipFromDb)
                    .Take(pageNumber)
                    .Select(x => new ProductCatalogViewModel
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price,
                        Avatar = x.Avatar,
                    })
                    .ToListAsync();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                ProductFilter = getAll,
            };

            return searchEmpty;
        }

        public async Task<ProductSearchViewModel> OrderProduct(int id, int category, int specification)
        {
            int page = id;

            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;

            List<ProductCatalogViewModel> getAll = await _productService.GetAll()
                //.Where(x => (x.ProductSingleBrand.Id == specification) && (x.ProductSubCategory.SingleOrDefault(x=>x.Id == category)))
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCatalogViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Avatar = x.Avatar,
                }).ToListAsync();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;
        }

        public async Task<ProductSearchViewModel> OrderProductByCategory(int id, string category)
        {
            int page = id;

            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            List<ProductCatalogViewModel> getAll = await _productService.GetAll()
                
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCatalogViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Avatar = x.Avatar,
                }).ToListAsync();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;
        }

        public async Task<ProductSearchViewModel> OrderProductBySpecificationId(int id, int categoryId)
        {
            int page = id;

            int allItemCount = _productService.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;

            List<ProductCatalogViewModel> getAll = await _productService.GetAll()
                //.Where(x => x.ProductSpecificationSingle.Id == categoryId)
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductCatalogViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Avatar = x.Avatar,
                }).ToListAsync();
            ProductSearchViewModel searchEmpty = new ProductSearchViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;
        }
    }
}
