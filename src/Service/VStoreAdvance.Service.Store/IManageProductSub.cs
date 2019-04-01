using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageProductSub : IManageProductSub
    {
        private IProductCategorySubService _productService;

        public ManageProductSub(IProductCategorySubService productService)
        {
            this._productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task CreateProduct(ProductCategoryViewModel model, string id)
        {
            await this._productService.Create(model.Category, Convert.ToInt32(id));
        }
        
        public async Task UpdateProduct(ProductCategoryViewModel model, string id)
        {
            await this._productService.Update(model.Category, Convert.ToInt32(id));
        }


        public async Task DeleteProduct(ProductCategoryViewModel model, string id)
        {
            await this._productService.Delete(model.Category, Convert.ToInt32(id));
        }

    }
}
