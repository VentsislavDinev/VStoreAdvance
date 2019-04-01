using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageProductSpecificationDetailService : ApplicationService, IManageProductSpecificationDetailService
    {

        private IProductSpecificationDetailService _productSpecificationService;

        public ManageProductSpecificationDetailService(IProductSpecificationDetailService productSpecificationService)
        {
            this._productSpecificationService = productSpecificationService ?? throw new ArgumentNullException(nameof(productSpecificationService));
        }

        public async Task CreateProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId)
        {
            await this._productSpecificationService.Create(model.Name, model.Description, productId, specificationId);
        }

        public async Task UpdateProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId)
        {
            await this._productSpecificationService.Update(model.Name, model.Description, productId, specificationId);
        }


        public async Task DeleteProduct(ProductSpecificationDetailManageViewModel model, int productId, int specificationId)
        {
            await this._productSpecificationService.Delete(model.Name, model.Description, productId, specificationId);
        }
    }
}
