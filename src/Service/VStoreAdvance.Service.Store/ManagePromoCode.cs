using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManagePromoCode : ApplicationService, IManagePromoCode
    {
        private IPromoCodeSerivice _promoCodeService;

        public ManagePromoCode(IPromoCodeSerivice promoCodeService)
        {
            this._promoCodeService = promoCodeService ?? throw new ArgumentNullException(nameof(promoCodeService));
        }


        public async Task CreateProduct(PromoCodeManageViewModel model)
        {
            await this._promoCodeService.Create(model.Code, model.CreatedOn, model.ValidFrom, model.ValidTo);
        }

        public async Task UpdateProduct(PromoCodeManageViewModel model)
        {
            await this._promoCodeService.Update(model.Code, model.CreatedOn, model.ValidFrom, model.ValidTo);
        }


        public async Task DeleteProduct(PromoCodeManageViewModel model)
        {
            await this._promoCodeService.Delete(model.Code, model.CreatedOn, model.ValidFrom, model.ValidTo);
        }

    }
}
