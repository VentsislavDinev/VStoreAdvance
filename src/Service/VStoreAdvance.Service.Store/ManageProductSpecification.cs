using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageProductSpecification : IManageProductSpecification
    {
        private IProductSpecificationService _productSpecificationService;

        public ManageProductSpecification(IProductSpecificationService productSpecificationService)
        {
            this._productSpecificationService = productSpecificationService ?? throw new ArgumentNullException(nameof(productSpecificationService));
        }
        
        public async Task CreateProduct(ProductSpecificationManageViewModel model, int productId)
        {
            await this._productSpecificationService.Create(model.Name, model.Description, productId);
        }

        public async Task UpdateProduct(ProductSpecificationManageViewModel model, int productId)
        {
            await this._productSpecificationService.Update(model.Name, model.Description, productId);
        }


        public async Task DeleteProduct(ProductSpecificationManageViewModel model, int productId)
        {
            await this._productSpecificationService.Delete(model.Name, model.Description, productId);
        }
    }
}
