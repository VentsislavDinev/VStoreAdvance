
using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using VStoreAdvances.Web.Areas.Administration.Controllers;

namespace HostingStore.Web.Areas.Administration.Controllers
{
    public class ProductSubParentCategoryController : BaseController
    {
        private  IManageProductSubParent _manageProductCategory;
        private IProductOrderSubParentCategoryService _productOrderSubParentCategory;
        public ProductSubParentCategoryController(IManageProductSubParent manageProductCategory, IProductOrderSubParentCategoryService productOrderSubParentCategory)
        {
            _manageProductCategory = manageProductCategory ?? throw new ArgumentNullException(nameof(manageProductCategory));
            _productOrderSubParentCategory = productOrderSubParentCategory ?? throw new ArgumentNullException(nameof(productOrderSubParentCategory));
        }

        // GET: Administration/ProductSubParentCategory
        public ActionResult Index(int id)
        {
            return View(_productOrderSubParentCategory.ListOrderProduct(id));
        }

        public ActionResult GetbyId(int id)
        {
            return View(_productOrderSubParentCategory.SingleOrderProduct(id));
        }


        public ActionResult Create(int id)
        {
            return View(_productOrderSubParentCategory.SingleOrderProduct(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCategoryViewModel mode, string id)
        {
            await _manageProductCategory.CreateProduct(mode, id);
            return Redirect("/");
        }

        public ActionResult Update(int id)
        {
            return View(_productOrderSubParentCategory.SingleOrderProduct(id));
        }
        [HttpPut]
        public async Task<ActionResult> Update(ProductCategoryViewModel model, string id)
        {
            await _manageProductCategory.UpdateProduct(model, id);
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(_productOrderSubParentCategory.SingleOrderProduct(id));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ProductCategoryViewModel model, string id)
        {
            await _manageProductCategory.DeleteProduct(model, id);
            return View();
        }
    }
}