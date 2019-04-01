using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using VStoreAdvances.Web.Areas.Administration.Controllers;

namespace HostingStore.Web.Areas.Administration.Controllers
{
    public class ProductController : BaseController
    {
        private const int pageNumber = 10;

        ///
        private const string imagePath = "/Files/uploads";
        private string saveMediumImageLocation;
        private IOrderProductList _orderProduct;
        private IManageProduct _manageProduct;
        private IDropdownListPopulator _populator;
        private ICacheService _cache;

        public ProductController(IOrderProductList orderProduct, ICacheService cache, IManageProduct manageProduct,IDropdownListPopulator populator)
        {
            _orderProduct = orderProduct ?? throw new ArgumentNullException(nameof(orderProduct));
            _manageProduct = manageProduct ?? throw new ArgumentNullException(nameof(manageProduct));
            _populator = populator ?? throw new ArgumentNullException(nameof(populator));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        }

        // GET: Administration/Default
        public ActionResult Index(int id=1)
        {

            return View(_orderProduct.OrderProduct(id));
        }

        public ActionResult GetById(string id)
        {
            return View(_orderProduct.SingleProduct (id));
        }

        public ActionResult Create()
        {
            _cache.Clear("specificationDetails");
            _cache.Clear("categories");
            _cache.Clear("specification");
            _cache.Clear("image");

            var sample = new ProductManageViewModel
            {
                Category = _populator.GetSubCategories(),
                SpecificationId = _populator.GetSpecification(),
                SpecificicationDetailId = _populator.GetSpecificationDetail(),
                BrandProduct = _populator.GetImages()
            };

            return View(sample);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductManageViewModel model, ICollection<string> specification, ICollection<string> category, ICollection<string> specificationDetail, ICollection<string> brands)
        {
            //if (ModelState.IsValid)
            //{
                var fileUpload = new WebImage(model.Avatar.InputStream).Resize(600, 460);

                var fileExtention = fileUpload.ImageFormat;

                //creating filename to avoid file name conflicts.
                var fileName = Guid.NewGuid().ToString();
                var curretnDirectory = Server.MapPath(imagePath);
                saveMediumImageLocation = curretnDirectory;

                string fileNameWithExtension = fileName + "." + fileExtention;

                //saving file in savedImage folder.
                var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
                fileUpload.Save(saveFile, fileExtention);
                await _manageProduct.CreateProduct(model, fileNameWithExtension, specification, category, specificationDetail, brands);
                return Redirect("/");
            //}
            //return Redirect("/administration/product/create");
        }

        public ActionResult CreateParent(int id, int categoryId, int parentId)
        {
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateParent(ProductManageViewModel model, int id, int categoryId, int parentId)
        //{
        //    var fileUpload = new WebImage(model.Avatar.InputStream).Resize(610, 460);

        //    var fileExtention = fileUpload.ImageFormat;

        //    //creating filename to avoid file name conflicts.
        //    var fileName = Guid.NewGuid().ToString();
        //    var curretnDirectory = Server.MapPath(imagePath);
        //    saveMediumImageLocation = curretnDirectory;

        //    string fileNameWithExtension = fileName + "." + fileExtention;

        //    //saving file in savedImage folder.
        //    var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
        //    fileUpload.Save(saveFile, fileExtention);
        //    await _manageProduct.CreateParentProduct(model, fileNameWithExtension, id, categoryId, parentId);
        //    return Redirect("/");
        //}

        public ActionResult ProductSpecification()
        {
            return PartialView();
        }

        public ActionResult GetProductBySpefication()
        {
            return PartialView();
        }

        public ActionResult GetProductByBrand()
        {
            return PartialView();
        }

        public ActionResult GetProductByPriceRange()
        {
            return PartialView();
        }
        public ActionResult BottomSideBar()
        {
            return PartialView();
        }

        public ActionResult GetProductByPromo()
        {
            return PartialView();
        }

        public ActionResult ProductRecommendet()
        {
            return PartialView();
        }

        public ActionResult LeftSideBar()
        {
            return PartialView();
        }


        public ActionResult Update()
        {
            return View();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductManageViewModel model, int id, int categoryId)
        {
            var fileUpload = new WebImage(model.Avatar.InputStream).Resize(610, 460);

            var fileExtention = fileUpload.ImageFormat;

            //creating filename to avoid file name conflicts.
            var fileName = Guid.NewGuid().ToString();
            var curretnDirectory = Path.GetFullPath(Server.MapPath(imagePath));
            saveMediumImageLocation = curretnDirectory;

            string fileNameWithExtension = fileName + "." + fileExtention;

            //saving file in savedImage folder.
            var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
            fileUpload.Save(saveFile, fileExtention);
            await _manageProduct.UpdateProduct(model, fileNameWithExtension, id, categoryId);
            return Redirect("/");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ProductManageViewModel model, int id, int categoryId)
        {
            var fileUpload = new WebImage(model.Avatar.InputStream).Resize(610, 460);

            var fileExtention = fileUpload.ImageFormat;

            //creating filename to avoid file name conflicts.
            var fileName = Guid.NewGuid().ToString();
            var curretnDirectory = Path.GetFullPath(Server.MapPath(imagePath));
            saveMediumImageLocation = curretnDirectory;

            string fileNameWithExtension = fileName + "." + fileExtention;

            //saving file in savedImage folder.
            var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
            fileUpload.Save(saveFile, fileExtention);
            await _manageProduct.UpdateProduct(model, fileNameWithExtension, id, categoryId);
            return Redirect("/");
        }
    }
}