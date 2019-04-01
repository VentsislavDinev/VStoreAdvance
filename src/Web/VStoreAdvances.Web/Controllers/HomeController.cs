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
using VStoreAdvance.Web.Service.Company;

namespace VStoreAdvance.Web.Controllers
{
    public class HomeController : BaseController
    {
        private const int pageNumber = 10;
        private IOrderProductList _orderProduct;

        private IProductOrderCategoryService _productOrderCategoryService;
        private readonly IProductOrderSpecificationService _productSpecificationService;
        private readonly IProductOrderSpecificationDetailsService _productOrderSpecificationDetailsService;
        private readonly IProductPromoHomeOrderService _productPromoHome;
        private readonly ICompanySerivice _companySerivice;
        private readonly IManageDeleveryInformationService _manageDelevery;
        private readonly IDeleveryInformationOrderService _orderDeleveryInformation;
        public HomeController(
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
        
        
        public async Task<ActionResult> OrderDetail()
        {

            PageViewModel page = new PageViewModel
            {
                ListProductBrand = await _orderProduct.ListBrandByProduct(),
                //OrderProduct = await _orderProduct.OrderProduct(id),
                ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                ProductPromoHome = await _productPromoHome.OrderProduct(),
                SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                Specification = await _productSpecificationService.ProductSpecification(),
                //DeleveryInformation = await _orderDeleveryInformation.GetSingleDeleveryInformation(),
                StaticPage = _companySerivice.Page.GetAll().Select(x => new StaticPageViewModel
                {
                    Name = x.Name,
                })
                                   .ToList(),

            };
            return View(page);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OrderDetail(PageViewModel model, string paymentMethod)
        {
            if (ModelState.IsValid)
            {
                DeleveryInformationViewModel deleveryInfo = new DeleveryInformationViewModel
                {
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    StreetNumber = model.StreetNumber,
                };

                await _manageDelevery.CreateProduct(deleveryInfo);
                //if (paymentMethod != null)
                //{

                    //ApplicationUser user2 = new ApplicationUser { UserName = model.Register.Email, Email = model.Register.Email };
                    //Microsoft.AspNet.Identity.IdentityResult result2 = await UserManager.CreateAsync(user2, model.Register.Password);
                    //if (result2.Succeeded)
                    //{
                    //    await SignInManager.SignInAsync(user2, isPersistent: false, rememberBrowser: false);

                    //    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //    // Send an email with this link
                    //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //}

                    return Redirect("/shoppingcart/payment");
                //}

                //ApplicationUser user = new ApplicationUser { UserName = model.Register.Email, Email = model.Register.Email };
                //Microsoft.AspNet.Identity.IdentityResult result = await UserManager.CreateAsync(user, model.Register.Password);
                //if (result.Succeeded)
                //{
                //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                //    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //    // Send an email with this link
                //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                //    return RedirectToAction("Index", "Home");
                //}


                return Redirect("/");
            }
            return Redirect("/shoppingcart/Index");
        }



        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            ShopingCartService cart = ShopingCartService.GetCart(HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        //[OutputCache(Duration = 60*60, Location = System.Web.UI.OutputCacheLocation.ServerAndClient)]
        public async Task<ActionResult> Index(int id = 1)
        {
            PageViewModel page = new PageViewModel
            {
                ListProductBrand = await _orderProduct.ListBrandByProduct(),
                OrderProduct = await _orderProduct.OrderProduct(id),
                ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                ProductPromoHome = await _productPromoHome.OrderProduct(),
                SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                Specification = await _productSpecificationService.ProductSpecification(),
                StaticPage = _companySerivice.Page.GetAll().Select(x => new StaticPageViewModel
                {
                    Name = x.Name,
                })
                                   .ToList()
            };
            return View(page);
        }


        public ActionResult About()
        {
            AboutViewModel getLastAboutPost = _companySerivice.About.GetAll()
                .OrderBy(x => x.CreatedOn)
                .Select(x => new AboutViewModel
                {
                    Description = x.Description,

                })
                .FirstOrDefault();

            return View(getLastAboutPost);
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 60 * 60 * 24)]
        private ActionResult Contacts()
        {
            CompanyContactViewModel contact = _companySerivice.Contact.GetAll().Where(x => x.Id == 1)
           .Select(x => new CompanyContactViewModel
           {
               Email = x.Email,
               WorkTo = x.WorkTo,
               OfficeAddress = x.OfficeCountry + " " + x.City + " " + x.Address,
               WorkFrom = x.WorkFrom,
               Phonenumber = x.Phonenumber
           })
           .SingleOrDefault();

            if (User.Identity.IsAuthenticated)
            {
                PageViewModel userPost = new PageViewModel
                {
                    Contact = contact,
                };

                return PartialView(userPost);
            }
            PageViewModel userRegister = new PageViewModel
            {
                Contact = contact,
            };

            return PartialView(userRegister);
        }

        [OutputCache(Duration = 2)]
        public ActionResult Contact()
        {
            return Contacts();
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

        public ActionResult Specification()
        {
            return PartialView();
        }

        public ActionResult ListByBrand()
        {

            return PartialView();
        }


        public JsonResult ParentCategory(string id)
        {
            return Json(new { data = "Sample" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Category()
        {
            return PartialView();
        }

        public ActionResult TopSideBar()
        {
            return PartialView();
        }

        public ActionResult LeftSideBar()
        {
            return PartialView();
        }

        public ActionResult BottomSideBar()
        {
            return PartialView();
        }

        //public ActionResult About()
        //{


        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}