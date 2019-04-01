
using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using VStoreAdvances.Web.Areas.Administration.Controllers;

namespace HostingStore.Web.Areas.Administration.Controllers
{
    public class ProductImageController : BaseController
    {
        private const int pageNumber = 10;

        private const string imagePath = "/Files/uploads";
        private string saveMediumImageLocation;
        private IProductImageList _productImage;
        private IManageProductImage _manageProduct;

        public ProductImageController(IProductImageList productImage, IManageProductImage manageProduct) 
        {
            _productImage = productImage ?? throw new ArgumentNullException(nameof(productImage));
            _manageProduct = manageProduct ?? throw new ArgumentNullException(nameof(manageProduct));
        }

        // GET: Administration/ProductIage
        public ActionResult Index(int id)
        {
            return View(_productImage.ListProductImage(id));
        }

        public ActionResult GetById(string id)
        {
            return View(_productImage.GetSingleProductImage(id));
        }
        public ActionResult Create(string id)
        {
            return View(_productImage.GetSingleProductImage(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductImageListViewModel data, string id)
        {
            var fileUpload = new WebImage(data.File.InputStream).Resize(610, 460);
        
        var fileExtention = fileUpload.ImageFormat;
            data.CreatedOn = DateTime.Now;
            data.ProductId = Convert.ToInt32(id);
            //creating filename to avoid file name conflicts.
            var fileName = Guid.NewGuid().ToString();
            var curretnDirectory = Server.MapPath(imagePath);
            saveMediumImageLocation = curretnDirectory;
           
            string fileNameWithExtension = fileName + "." + fileExtention;

            //saving file in savedImage folder.
            var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
            fileUpload.Save(saveFile, fileExtention);
            await _manageProduct.CreateProduct(data,  fileNameWithExtension);
            return Redirect("/");
        }

        public ActionResult Update(string id)
        {
            return View(_productImage.GetSingleProductImage(id));
        }
        [HttpPut]
        public async Task<ActionResult> Update(ProductImageListViewModel data)
        {
            var fileUpload = new WebImage(data.File.InputStream).Resize(610, 460);

            var fileExtention = fileUpload.ImageFormat;

            //creating filename to avoid file name conflicts.
            var fileName = Guid.NewGuid().ToString();
            var curretnDirectory = Server.MapPath(imagePath);
            saveMediumImageLocation = curretnDirectory;

            string fileNameWithExtension = fileName + "." + fileExtention;

            //saving file in savedImage folder.
            var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
            fileUpload.Save(saveFile, fileExtention);
            await _manageProduct.UpdateProduct(data, fileNameWithExtension);
            return Redirect("/");
        }
        public ActionResult Delete(string id)
        {
            return View(_productImage.GetSingleProductImage(id));
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(ProductImageListViewModel data)
        {
            var fileUpload = new WebImage(data.File.InputStream).Resize(150, 150);

            var fileExtention = fileUpload.ImageFormat;
            
            //creating filename to avoid file name conflicts.
            var fileName = Guid.NewGuid().ToString();
            var curretnDirectory = Server.MapPath(imagePath);
            saveMediumImageLocation = curretnDirectory;

            string fileNameWithExtension = fileName + "." + fileExtention;

            //saving file in savedImage folder.
            var saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
            fileUpload.Save(saveFile, fileExtention);
            await _manageProduct.DeleteProduct(data, fileNameWithExtension);
            return Redirect("/");
        }
    }
}