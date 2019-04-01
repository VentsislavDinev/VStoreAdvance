using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageProductCategory : ApplicationService, IManageProductCategory
    {
        private IProductCategoryService _productService;

        public ManageProductCategory(IProductCategoryService productService)
        {
            this._productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task CreateProduct(ProductCategoryViewModel model)
        {
            await this._productService.Create(model.Category);
        }


        public async Task CreateProductCategory(ProductCategoryViewModel model, int categoryId)
        {
            await this._productService.CreateCategory(model.Category, categoryId);
        }



        public async Task CreateProductParrentCategory(ProductCategoryViewModel model, int categoryId)
        {
            await this._productService.CreateParrentCategory(model.Category, categoryId);
        }

        public async Task UpdateProduct(ProductCategoryViewModel model)
        {
            await this._productService.Update(model.Category);
        }


        public async Task DeleteProduct(ProductCategoryViewModel model)
        {
            await this._productService.Delete(model.Category);
        }
    }
}
