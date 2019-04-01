
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

    public class ProductCategoryController : BaseController
    {
        private IManageProductCategory _manageProductCategory;
        private IProductOrderCategoryService _productOrderCategory;
        public IManageProductCategory ManageProductCategory { get => _manageProductCategory; set => _manageProductCategory = value; }

        public ProductCategoryController(
            IManageProductCategory manageProductCategory, 
            IProductOrderCategoryService productOrderCategory) 
        {
            _productOrderCategory = productOrderCategory ?? throw new ArgumentNullException(nameof(productOrderCategory));
            ManageProductCategory = manageProductCategory ?? throw new ArgumentNullException(nameof(manageProductCategory));
        }
        

        // GET: Administration/ProductCategory
        public ActionResult Index(int? id)
        {
            var data = _productOrderCategory.ListOrderProduct(id);

            return View(data);
        }
        public ActionResult IndexSubCategory(int id = 1)
        {
            return View(_productOrderCategory.OrderProduct(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateSubCategory(int id)
        {
            
            return View(_productOrderCategory.SingleOrderProduct(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubCategory(ProductCategoryViewModel model, int id =0)
        {
            await ManageProductCategory.CreateProductCategory(model, id);
            return Redirect("/IndexSubCategory");
        }

        public ActionResult IndexParrentCategory(int name, int id)
        {
            return View(_productOrderCategory.OrderProduct(id));
        }

        public ActionResult CreateSubParrentCategory(int id)
        {

            return View(_productOrderCategory.OrderProduct(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubParrentCategory(ProductCategoryViewModel model, int id)
        {
            await ManageProductCategory.CreateProductParrentCategory(model, id);
            return Redirect("/");
            
        }
        [HttpPost]
        public async Task< ActionResult> Create(ProductCategoryViewModel model)
        {
            await  ManageProductCategory.CreateProduct(model);
            return Redirect("/");
        }

        public ActionResult Update()
        {
            return View();
        }
        [HttpPut]
        public ActionResult Update(ProductCategoryViewModel model)
        {
            return View(ManageProductCategory.UpdateProduct(model));
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(ProductCategoryViewModel model)
        {
            return View(ManageProductCategory.UpdateProduct(model));
        }
    }
}