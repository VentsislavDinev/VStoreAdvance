using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VStoreAdvances.Web.Areas.Administration.Controllers;

namespace HostingStore.Web.Areas.Administration.Controllers
{
    public class ProductSpecificationController : BaseController
    {
        private IManageProductSpecification _productSpecificationMenage;
        private IProductOrderSpecificationService _productSpecificationService;
        private IDropdownListPopulator _populator;

        private ICacheService _cache;
        public ProductSpecificationController( IDropdownListPopulator populator, ICacheService cache, IManageProductSpecification productSpecificationMenage, IProductOrderSpecificationService productSpecificationService)
        {
            _productSpecificationMenage = productSpecificationMenage ?? throw new ArgumentNullException(nameof(productSpecificationMenage));
            _productSpecificationService = productSpecificationService ?? throw new ArgumentNullException(nameof(productSpecificationService));
            _populator = populator ?? throw new ArgumentNullException(nameof(populator));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        // GET: Administration/ProductSpecification
        public ActionResult Index(int? id )
        {
          
            return View(_productSpecificationService.ProductSpecification());
        }

        public ActionResult GetbyId(int id)
        {
            return View(_productSpecificationService.ListProductSpecificationByProductName(id));
        }

        public ActionResult Create(string id)
        {
            _cache.Clear("specificationDetails");
            _cache.Clear("categories");
            _cache.Clear("specification");

            var sample = new ProductSpecificationManageViewModel
            {
                Category = _populator.GetSubCategories()
            };

            return View(sample);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductSpecificationManageViewModel model)
        {
            await _productSpecificationMenage.CreateProduct(model, model.CategoryId);
            return Redirect("/");
        }

        public ActionResult Update(string id)
        {
            return View(_productSpecificationService.SingleProductSpecificationByProductName(id));
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductSpecificationManageViewModel model, string id)
        {
            await _productSpecificationMenage.UpdateProduct(model, Convert.ToInt32(id));
            return Redirect("/");
        }

        public ActionResult Delete(string id)
        {
            return View(_productSpecificationService.SingleProductSpecificationByProductName(id));
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(ProductSpecificationManageViewModel model, string id)
        {
            await _productSpecificationMenage.DeleteProduct(model, Convert.ToInt32(id));
            return Redirect("/");
        }
    }
}