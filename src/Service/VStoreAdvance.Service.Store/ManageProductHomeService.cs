using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageProductHomeService : ApplicationService, IManageProductHomeService
    {
        private IProductPromoHomeService _productPromoHomeService;

        public ManageProductHomeService(IProductPromoHomeService productPromoHomeService)
        {
            _productPromoHomeService = productPromoHomeService ?? throw new ArgumentNullException(nameof(productPromoHomeService));
        }


        public async Task Create(ProductHomeServiceViewModel model)
        {
            await this._productPromoHomeService.Create(model.Name, model.Description, model.Avatar, model.Price);
        }

        
        public async Task Update(ProductHomeServiceViewModel model)
        {
            await this._productPromoHomeService.Update(model.Name, model.Description, model.Avatar, model.Price);
        }


        public async Task DeleteProduct(ProductHomeServiceViewModel model)
        {
            await this._productPromoHomeService.Delete(model.Name, model.Description, model.Avatar, model.Price);
        }
    }
}
