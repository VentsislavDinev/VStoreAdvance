using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VStoreAdvances.Web.Areas.Administration.Controllers;

namespace HostingStore.Web.Areas.Administration.Controllers
{
    public class PromoCampaingController : BaseController
    {

        private IManagePromoCode _promoCode;
        private IPromoCodeOrder _promoCodeService;

        public PromoCampaingController(IManagePromoCode promoCode, IPromoCodeOrder promoCodeService)
        {
            this._promoCode = promoCode ?? throw new ArgumentNullException(nameof(promoCode));
            this._promoCodeService = promoCodeService ?? throw new ArgumentNullException(nameof(promoCodeService));
        }

        // GET: Administration/PromoCampaing
        public ActionResult Index(int id)
        {
            return View(_promoCodeService.OrderPromoCode(id));
        }

        public ActionResult GetById(string name)
        {
            return View(_promoCodeService.SinglePromoCode(name));
        }

        public ActionResult Delete(PromoCodeManageViewModel model)
        {
            return View(_promoCode.CreateProduct(model));
        }

        public ActionResult Update(PromoCodeManageViewModel model) { return View(_promoCode.CreateProduct(model)); }

        public ActionResult Create(PromoCodeManageViewModel model)
        {
            return View(_promoCode.CreateProduct(model));
        }
    }
}