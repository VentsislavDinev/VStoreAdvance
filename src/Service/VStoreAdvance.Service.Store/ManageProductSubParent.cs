//using HostingStore.ProductViewModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HostingStore.ProductService
//{
//    public class ManageProductSubParent : IManageProductSubParent
//    {
//        private IProductSubParentService _productImageService;

//        public ManageProductSubParent(IProductSubParentService productImageService)
//        {
//            this._productImageService = productImageService ?? throw new ArgumentNullException(nameof(productImageService));
//        }

//        public async Task CreateProduct(ProductCategoryViewModel model, string id)
//        {
//            await this._productImageService.Create(model.Category, Convert.ToInt32(id));
//        }

//        public async Task UpdateProduct(ProductCategoryViewModel model, string id)
//        {
//            await this._productImageService.Update(model.Category, Convert.ToInt32(id));
//        }


//        public async Task DeleteProduct(ProductCategoryViewModel model, string id)
//        {
//            await this._productImageService.Delete(model.Category,  Convert.ToInt32(id));
//        }
//    }
//}
