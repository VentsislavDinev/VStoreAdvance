using HostingsStore.ProductService;
using hostingstore.productservice;
using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VAgency.Data.ViewModels;
using VStoreAdvance.Data.EntityFramework;
using VStoreAdvance.Web.Service.Company;

namespace VStoreAdvance.Web.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private VStoreAdvanceDbContext storeDb = new VStoreAdvanceDbContext();
        private const int pageNumber = 10;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategory;
        private readonly IProductImageService _productImage;
        private readonly IProductReviewService _productReview;
        private readonly IShopingCartService _shopingCart;
        private IOrderProductList _orderProduct;
        private IProductOrderCategoryService _productOrderCategoryService;
        private readonly IProductOrderSpecificationService _productSpecificationService;
        private readonly IProductOrderSpecificationDetailsService _productOrderSpecificationDetailsService;
        private readonly IProductPromoHomeOrderService _productPromoHome;
        private readonly ICompanySerivice _companySerivice;
        private readonly IManageDeleveryInformationService _manageDelevery;
        private readonly IDeleveryInformationOrderService _orderDeleveryInformation;
        public ShoppingCartController(
            IOrderProductList orderProduct,
            ProductOrderCategoryService productOrderCategoryService,
            IProductOrderSpecificationService productOrderSpecificationService,
            IProductOrderSpecificationDetailsService productOrderSpecificationDetailsService,
            IProductPromoHomeOrderService productPromoHome,
            ICompanySerivice companySerivice,
            IManageDeleveryInformationService manageDelevery,
            IDeleveryInformationOrderService orderDeleveryInformation) 
        {
            _orderProduct = orderProduct ?? throw new ArgumentNullException(nameof(orderProduct));
            _productPromoHome = productPromoHome ?? throw new ArgumentNullException(nameof(productPromoHome));
            _productOrderCategoryService = productOrderCategoryService ?? throw new ArgumentNullException(nameof(productOrderCategoryService));
            _productSpecificationService = productOrderSpecificationService ?? throw new ArgumentNullException(nameof(productOrderSpecificationService));
            _productOrderSpecificationDetailsService = productOrderSpecificationDetailsService ?? throw new ArgumentNullException(nameof(productOrderSpecificationDetailsService));
            _companySerivice = companySerivice ?? throw new ArgumentNullException(nameof(companySerivice));
            _manageDelevery = manageDelevery ?? throw new ArgumentNullException(nameof(manageDelevery));
            _orderDeleveryInformation = orderDeleveryInformation ?? throw new ArgumentNullException(nameof(orderDeleveryInformation));
        }

        //
        // GET: /ShoppingCart/
        public async Task<ActionResult> Index()
        {
            ShopingCartService cart = ShopingCartService.GetCart(HttpContext);

            // Set up our ViewModel
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };



            PageViewModel page = new PageViewModel
            {
                ListProductBrand = await _orderProduct.ListBrandByProduct(),

                ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                ProductPromoHome = await _productPromoHome.OrderProduct(),
                SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                Specification = await _productSpecificationService.ProductSpecification(),
                StaticPage = _companySerivice.Page.GetAll().Select(x => new StaticPageViewModel
                {
                    Name = x.Name,
                })
                                   .ToList(),
                ShoppingCart = viewModel
            };
            // Return the view
            return View(page);
        }


        [ChildActionOnly]
        //[OutputCache(Duration = 60 * 60 * 24)]
        public ActionResult GetStaticPage()
        {
            System.Collections.Generic.List<StaticPageViewModel> getStaticPage = _companySerivice.Page.GetAll()
           .Select(x => new StaticPageViewModel
           {
               Name = x.Name,
           })
           .ToList();
            if (User.Identity.IsAuthenticated)
            {
                PageViewModel userPost = new PageViewModel
                {
                    StaticPage = getStaticPage,
                };

                return PartialView(userPost);
            }

            PageViewModel userRegister = new PageViewModel
            {
                StaticPage = getStaticPage,
            };

            return PartialView(userRegister);
        }

        public ActionResult Payment()
        {
            string siteUrl = Request.Url.GetLeftPart(UriPartial.Authority);

            int projectId = 136318;
            string signPassword = "67d9827f9c944051d5bf2823c94179fe";

            Client client = new Client(projectId, signPassword);

            // Make a new request
            MacroRequest request = client.NewMacroRequest();

            // Should be saved somewhere and unique for every request.
            request.OrderId = "ORDER0001";
            request.Amount = 1000;
            request.Currency = "EUR";
            request.Country = "LT";
            request.AcceptUrl = siteUrl + "/Accept";
            request.CancelUrl = siteUrl + "/Cancel";
            request.CallbackUrl = siteUrl + "/MacroCallback";

            // Change this to "true" if you want to test
            request.Test = false;

            string redirectUrl = client.BuildRequestUrl(request);
            return Redirect(redirectUrl);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            HostingStore.Products.Product addedAlbum = storeDb.Products
                .Single(album => album.Id == id);

            // Add it to the shopping cart
            ShopingCartService cart = ShopingCartService.GetCart(HttpContext);

            cart.AddToCart(addedAlbum);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            ShopingCartService cart = ShopingCartService.GetCart(HttpContext);

            // Get the name of the album to display confirmation
            string albumName = storeDb.Carts
                .Single(item => item.RecordId == id).Product.Name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            ShoppingCartRemoveViewModel results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            ShopingCartService cart = ShopingCartService.GetCart(HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}