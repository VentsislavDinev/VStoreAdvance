
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
    public class ProductSpecificationDetailController : BaseController
    {
        private IOrderProductList _orderProduct;
        private IProductOrderCategoryService _productOrderCategoryService;
        private IManageProductSpecificationDetailService _manageProductSpecificationDetailService;
        private IManageProductSpecification manageProductSpecification;
        private IProductOrderSpecificationDetailsService _productOrderSpecificationDetailsService;

        private IProductOrderSpecificationService _productOrderSpecificatioнService;

        public IProductOrderSpecificationService ProductOrderSpecificatioнService { get => _productOrderSpecificatioнService; set => _productOrderSpecificatioнService = value; }
        private IDropdownListPopulator _populator;

        public ProductSpecificationDetailController( IDropdownListPopulator populator,  IOrderProductList orderProduct, IProductOrderSpecificationService productOrderSpecificatioнService, IProductOrderSpecificationDetailsService productOrderSpecificationDetailsService, IProductOrderCategoryService productOrderCategoryService, IManageProductSpecificationDetailService manageProductSpecificationDetailService, IManageProductSpecification manageProductSpecification)
        {
            _orderProduct = orderProduct ?? throw new ArgumentNullException(nameof(orderProduct));
            _productOrderCategoryService = productOrderCategoryService ?? throw new ArgumentNullException(nameof(productOrderCategoryService));
            _manageProductSpecificationDetailService = manageProductSpecificationDetailService ?? throw new ArgumentNullException(nameof(manageProductSpecificationDetailService));
            this.manageProductSpecification = manageProductSpecification ?? throw new ArgumentNullException(nameof(manageProductSpecification));
            this._productOrderSpecificationDetailsService = productOrderSpecificationDetailsService ?? throw new ArgumentNullException(nameof(productOrderSpecificationDetailsService));
            this.ProductOrderSpecificatioнService = productOrderSpecificatioнService ?? throw new ArgumentNullException(nameof(productOrderSpecificatioнService));
            _populator = populator ?? throw new ArgumentNullException(nameof(populator));
        }

        public async Task<ActionResult> Index(int? id)
        {
            var pageView = new PageViewModel {
                 ProductDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail()
            };

            return View(pageView);
        }

        public ActionResult GetById()
        {
            return View();
        }
        public ActionResult Create(int? id)
        {
            var sample = new ProductSpecificationDetailManageViewModel
            {
                Category = _populator.GetSubCategories(),
                SpecificationId = _populator.GetSpecification(),
            };

            return View(sample);
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductSpecificationDetailManageViewModel model)
        {

            await _manageProductSpecificationDetailService.CreateProduct(model, model.Specification, model.CategoryId);
            return Redirect("/");
        }

        public ActionResult Update(int id, int productId)
        {
            return View();
        }
        [HttpPut]
        public async Task <ActionResult> Update(ProductSpecificationDetailManageViewModel model, int productId, int id)
        {
            await _manageProductSpecificationDetailService.UpdateProduct(model, productId, id);
            return Redirect("/");
        }
      
        public ActionResult Delete(int id, int productId)
        {
            return View();
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(ProductSpecificationDetailManageViewModel model, int productId, int id)
        {
            await _manageProductSpecificationDetailService.DeleteProduct(model, productId, id);
            return Redirect("/");
        }

    }
}