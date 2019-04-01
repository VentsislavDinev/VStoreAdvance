using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using VStoreAdvances.Web.Areas.Administration.Controllers;

namespace HostingStore.Web.Areas.Administration.Controllers
{
    public class ProductBrandController : BaseController
    {  
        ///
        private const string imagePath = "/Files/uploads";
        private readonly IManageProductBrand _manageProductBrand;

        private string saveMediumImageLocation;
        private readonly IProductBrandOrderService _productBrandOrder;

        public ProductBrandController(IManageProductBrand manageProductBrand, IProductBrandOrderService productBrandOrder) 
        {
            _manageProductBrand = manageProductBrand ?? throw new ArgumentNullException(nameof(manageProductBrand));
            _productBrandOrder = productBrandOrder ?? throw new ArgumentNullException(nameof(productBrandOrder));
        }

        // GET: Administration/ProductBrand
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductBrandViewModel model)
        {
            var fileUpload = new WebImage(model.Avatar.InputStream).Resize(610, 460);

            var fileExtention = fileUpload.ImageFormat;

            //creating filename to avoid file name conflicts.
            var fileName = Guid.NewGuid().ToString();
            var curretnDirectory = Server.MapPath(imagePath);
            saveMediumImageLocation = curretnDirectory;

            string fileNameWithExtension = fileName + "." + fileExtention;

            //saving file in savedImage folder.
            var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
            fileUpload.Save(saveFile, fileExtention);

            model.Image = fileNameWithExtension;

            await _manageProductBrand.Create(model);

            return Redirect("/");
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPut]
        public async Task<ActionResult> Update(ProductBrandViewModel model)
        {
            await _manageProductBrand.Update(model);

            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(ProductBrandViewModel model)
        {
            await _manageProductBrand.Delete(model);
            return View();
        }
    }
}