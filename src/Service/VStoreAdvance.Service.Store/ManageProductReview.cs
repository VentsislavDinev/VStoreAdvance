using Abp.Application.Services;
using Abp.Domain.Entities;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public  class ManageProductReview : Entity
    {
        private IProductReviewService _productImageService;

        public ManageProductReview(IProductReviewService productImageService)
        {
            this._productImageService = productImageService ?? throw new ArgumentNullException(nameof(productImageService));
        }

        public async Task CreateProduct(ProductReviewManageViewModel model)
        {
            await this._productImageService.Create(model.UserName, model.Comment, model.CreatedOn);
        }

        public async Task UpdateProduct(ProductReviewManageViewModel model)
        {
            await this._productImageService.Update(model.UserName, model.Comment, model.CreatedOn);
        }


        public async Task DeleteProduct(ProductReviewManageViewModel model)
        {
            await this._productImageService.Delete(model.UserName, model.Comment, model.CreatedOn);
        }
    }
}
