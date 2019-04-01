
//using Abp.Application.Services;
//using Abp.Domain.Repositories;
//using HostingStore.Products;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HostingStore.ProductService
//{
//    public class PromoCodeSerivice : ApplicationService, IPromoCodeSerivice
//    {
//        private readonly IRepository<Product> _product;

//        /// <summary>
//        /// The repo
//        /// </summary>
//        private readonly IRepository<ManageProductReview> _repo;

//        private readonly IRepository<PromoCode> _promoCode;

//        private readonly IRepository<ProductCategory> _productCategory;
//        private readonly IRepository<ManageProductReview> _productReview;
//        private readonly IRepository<Order> _order;

//        public PromoCodeSerivice( IRepository<Product> product, IRepository<ManageProductReview> productReview, IRepository<ManageProductReview> repo, IRepository<PromoCode> category, IRepository<ProductCategory> productCategory, IRepository<Order> order)
//        {
//            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
//            _promoCode = category ?? throw new ArgumentNullException(nameof(category));
//            _productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
//            _order = order ?? throw new ArgumentNullException(nameof(order));
//            _productReview = productReview ?? throw new ArgumentException(nameof(productReview));
//            _product = product ?? throw new ArgumentException(nameof(product));
//        }

//        public async Task<PromoCode> Create(string code, DateTime? createdOn, DateTime? ValidFrom, DateTime? validTo)
//        {
//            PromoCode newProduct = new PromoCode
//            {
//                Code = code,
//                CreatedOn = createdOn,
//                ValidFrom = ValidFrom,
//                ValidTo = validTo,
//            };

//           await  _promoCode.InsertAsync(newProduct);
          
//            return newProduct;
//        }


//        public async Task<PromoCode> Update(string code, DateTime? createdOn, DateTime? ValidFrom, DateTime? validTo)
//        {
//            PromoCode newProduct = new PromoCode
//            {
//                Code = code,
//                CreatedOn = createdOn,
//                ValidFrom = ValidFrom,
//                ValidTo = validTo,
//            };

//           await   _promoCode.UpdateAsync(newProduct);
           
//            return newProduct;
//        }


//        public async Task<PromoCode> Delete(string code, DateTime? createdOn, DateTime? ValidFrom, DateTime? validTo)
//        {
//            PromoCode newProduct = new PromoCode
//            {
//                Code = code,
//                CreatedOn = createdOn,
//                ValidFrom = ValidFrom,
//                ValidTo = validTo,
//            };

//           await  _promoCode.DeleteAsync(newProduct);
           
//            return newProduct;
//        }

//        public IQueryable<PromoCode> GetAll()
//        {
//            return _promoCode.GetAll();
//        }

//        public IQueryable<PromoCode> GetById(int id)
//        {
//            return this._promoCode.GetAll().Where(x => x.Id == id);
//        }

//        public IQueryable<PromoCode> GetByName(string code)
//        {
//            return this._promoCode.GetAll().Where(x => x.Code == code);
//        }
//    }
//}
