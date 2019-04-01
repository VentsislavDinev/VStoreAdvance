
using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using VStoreAdvances.Web.Areas.Administration.Controllers;

namespace HostingStore.Web.Areas.Administration.Controllers
{
    public class ProductSubCategoryController : BaseController
    {
        private IManageProductSub _manageProductCategory;
        private IProductOrderCategorySubService _orderSubCategory;
        public ProductSubCategoryController(IManageProductSub manageProductCategory, IProductOrderCategorySubService orderSubCategory) 
        {
            ManageProductCategory = manageProductCategory ?? throw new ArgumentNullException(nameof(manageProductCategory));
            _orderSubCategory = orderSubCategory ?? throw new ArgumentNullException(nameof(orderSubCategory));
        }

        public IManageProductSub ManageProductCategory { get => _manageProductCategory; set => _manageProductCategory = value; }

        // GET: Administration/ProductSubCategory
        public async Task<ActionResult> Index(int id)
        {
        
            return View( await _orderSubCategory.OrderProduct(id));
        }
        public async Task<ActionResult> GetById(int id)
        {
            return View(await _orderSubCategory.SingleOrderProduct(id));
        }


        public async Task<ActionResult> Create(int id)
        {
            return View( await _orderSubCategory.SingleOrderProduct(id));
        }

      
        [HttpPost]
        public async Task<ActionResult> Create(ProductCategoryViewModel data, string id)
        {
            await _manageProductCategory.CreateProduct(data, id);
            return Redirect("/");
        }

        public ActionResult Update(int id)
        {
            return View(_orderSubCategory.SingleOrderProduct(id));
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductCategoryViewModel data, string id)
        {
            await _manageProductCategory.CreateProduct(data, id);
            return Redirect("/");
        }
        

        public ActionResult Delete(int id)
        {
            return View(_orderSubCategory.SingleOrderProduct(id));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ProductCategoryViewModel data, string id)
        {
            await _manageProductCategory.CreateProduct(data, id);
            return Redirect("/");
        }
    }
}