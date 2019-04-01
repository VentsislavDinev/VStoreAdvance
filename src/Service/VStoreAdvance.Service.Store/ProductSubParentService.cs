//using HostingStore.Common;
//using HostingStore.Data;
//using HostingStore.Products;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HostingStore.ProductService
//{
//    public class ProductSubParentService : IProductSubParentService
//    {
//        /// <summary>
//        /// The company system data
//        /// </summary>
//        ///
//        private IStoreSystemData _blogSystemData;


//        /// <summary>
//        /// The repo
//        /// </summary>
//        private readonly IRepository<ProductSubParrentCategory> _productCategorySub;

//        public ProductSubParentService(IStoreSystemData blogSystemData, IRepository<ProductSubParrentCategory> productCategorySub)
//        {
//            BlogSystemData = blogSystemData ?? throw new ArgumentNullException(nameof(blogSystemData));
//            _productCategorySub = productCategorySub ?? throw new ArgumentNullException(nameof(productCategorySub));
//        }


//        public async Task<ProductSubParrentCategory> Create(string category, int id)
//        {
//            ProductSubParrentCategory createProductCategory = new ProductSubParrentCategory
//            {
//                Category = category,
//                ProductSubCategoryID = id
//            };

//            _productCategorySub.Add(createProductCategory);
//            try
//            {
//                await _productCategorySub.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            return createProductCategory;
//        }


//        public async Task<ProductSubParrentCategory> Update(string category, int id)
//        {
//            ProductSubParrentCategory createProductCategory = new ProductSubParrentCategory
//            {
//                Category = category,
//                ProductSubCategoryID = id
//            };

//            _productCategorySub.Update(createProductCategory);
//            try
//            {
//                await _productCategorySub.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            return createProductCategory;
//        }


//        public async Task<ProductSubParrentCategory> Delete(string category, int id)
//        {
//            ProductSubParrentCategory createProductCategory = new ProductSubParrentCategory
//            {
//                Category = category,
//                ProductSubCategoryID = id
//            };

//            _productCategorySub.Delete(createProductCategory);
//            try
//            {
//                await _productCategorySub.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            return createProductCategory;
//        }

//        public IQueryable<ProductSubParrentCategory> GetAll()
//        {
//            return _productCategorySub.All();
//        }

//        public IQueryable<ProductSubParrentCategory> GetById(int id)
//        {
//            return _productCategorySub.All().Where(x => x.ProductSubCategoryID == id);
//        }

//        public IQueryable<ProductSubParrentCategory> GetByName(string category)
//        {
//            return _productCategorySub.All().Where(x => x.Category == category);
//        }

//        //private ISanitizer _sanitize;

//        // public IRepository<BlogImages> BlogImage { get => _blogImage; set => _blogImage = value; }
//        // public ISanitizer Sanitize { get => _sanitize; set => _sanitize = value; }
//        public IStoreSystemData BlogSystemData { get => _blogSystemData; set => _blogSystemData = value; }



//    }
//}
