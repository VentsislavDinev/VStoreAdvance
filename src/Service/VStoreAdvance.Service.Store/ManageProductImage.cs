using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageProductImage : IManageProductImage
    {
        private IProductImageService _productImageService;

        public ManageProductImage(IProductImageService productImageService)
        {
            this._productImageService = productImageService ?? throw new ArgumentNullException(nameof(productImageService));
        }

        public async Task CreateProduct(ProductImageListViewModel model, string file)
        {
            await this._productImageService.Create(file, model.CreatedOn, model.ProductId);
        }

        public async Task UpdateProduct(ProductImageListViewModel model, string file)
        {
            await this._productImageService.Update(file, model.CreatedOn, model.ProductId);
        }


        public async Task DeleteProduct(ProductImageListViewModel model, string file)
        {
            await this._productImageService.Delete(file, model.CreatedOn, model.ProductId);
        }
    }
}
