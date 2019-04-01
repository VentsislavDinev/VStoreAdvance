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
    public class PolicyController : BaseController
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
        public PolicyController(
            IOrderProductList orderProduct,
            ProductOrderCategoryService productOrderCategoryService,
            IProductOrderSpecificationService productOrderSpecificationService,
            IProductOrderSpecificationDetailsService productOrderSpecificationDetailsService,
            IProductPromoHomeOrderService productPromoHome,
            ICompanySerivice companySerivice,
            IManageDeleveryInformationService manageDelevery,
            IDeleveryInformationOrderService orderDeleveryInformation
           ) 
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



        [ChildActionOnly]
        //[OutputCache(Duration = 60 * 60 * 24)]
        public async Task<ActionResult> GetStaticPage()
        {
            List<StaticPageViewModel> getStaticPage = _companySerivice.Page.GetAll()
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



        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            ShopingCartService cart = ShopingCartService.GetCart(HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        //[ChildActionOnly]
        ////[OutputCache(Duration = 60 * 60 * 24)]
        //private ActionResult Contacts()
        //{
        //    var contact = this.Company.Contact.GetAll().Where(x => x.Id == 1)
        //   .Select(x => new CompanyContactViewModel
        //   {
        //       Email = x.Email,
        //       WorkTo = x.WorkTo,
        //       OfficeAddress = x.OfficeCountry + " " + x.City + " " + x.Address,
        //       WorkFrom = x.WorkFrom,
        //       Phonenumber = x.Phonenumber
        //   })
        //   .SingleOrDefault();
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        PageViewModel userPost = new PageViewModel
        //        {
        //            StaticPage = contact,
        //        };

        //        return PartialView(userPost);
        //    }

        //    PageViewModel userRegister = new PageViewModel
        //    {
        //        StaticPage = contact,
        //    };

        //    return PartialView(userRegister);
        //}

        //[OutputCache(Duration = 2)]
        //public ActionResult Contact()
        //{
        //    return Contacts();
        //}
        [HttpGet]
        public async Task<ActionResult> Index(string id)
        {
            StaticPageViewModel getById = _companySerivice.Page.GetAll().Where(x => x.Name == id)
            .Select(x => new StaticPageViewModel
            {
                CreatedOn = x.CreatedOn,
                Description = x.Description,
                Name = x.Name
            })
            .SingleOrDefault();

            if (User.Identity.IsAuthenticated)
            {
                PageViewModel userPost = new PageViewModel
                {
                    ListProductBrand = await _orderProduct.ListBrandByProduct(),
                    //OrderProduct = await _orderProduct.OrderProduct(id),
                    ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                    ProductPromoHome = await _productPromoHome.OrderProduct(),
                    SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                    Specification = await _productSpecificationService.ProductSpecification(),
                    GetSingleStaticPage = getById,
                };

                return View(userPost);
            }

            PageViewModel userRegister = new PageViewModel
            {
                ListProductBrand = await _orderProduct.ListBrandByProduct(),
                //OrderProduct = await _orderProduct.OrderProduct(id),
                ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                ProductPromoHome = await _productPromoHome.OrderProduct(),
                SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                Specification = await _productSpecificationService.ProductSpecification(),
                GetSingleStaticPage = getById,
            };

            return View(userRegister);
        }


        //public ActionResult SEO()
        //{
        //    if (!this.Company.Seo.All().Any())
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        //    }
        //    var seo = this.Company.Seo.All()
        //        .Select(x => new SEOToolViewModel
        //        {
        //            AppId = x.AppId,
        //            GOogleAnalytics = x.GoogleAnalytics,
        //            GoogleVerify = x.GoogleVerify,
        //            ImageName = x.ImageName,
        //            Keyword = x.Keywords,
        //            MsValidator = x.MsValidator,
        //            SiteDescription = x.SiteDescription,
        //            SiteName = x.SiteName,
        //            URL = x.URL,
        //            YandexNumber = x.YandexNumber,
        //        })
        //        .FirstOrDefault();
        //    return PartialView(seo);
        //}

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

    }
}