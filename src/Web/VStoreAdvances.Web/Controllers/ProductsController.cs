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
    public class ProductsController : BaseController
    {

        private const int pageNumber = 10;
        private IOrderProductList _orderProduct;
        private IProductOrderCategoryService _productOrderCategoryService;
        private readonly IProductOrderCategorySubService _productOrderCategorySubService;
        private IProductOrderImageService _productOrderImageService;
        private readonly IProductOrderSpecificationService _productSpecificationService;
        private readonly IProductBrandOrderService _productBrandOrder;
        private readonly IProductOrderSpecificationDetailsService _productOrderSpecificationDetailsService;
        private readonly ICompanySerivice _companySerivice;
        public ProductsController(
            IOrderProductList orderProduct,
            ProductOrderCategoryService productOrderCategoryService,
            IProductOrderSpecificationService productOrderSpecificationService,
            IProductOrderSpecificationDetailsService productOrderSpecificationDetailsService,
            IProductOrderImageService productOrderImageService,
            IProductBrandOrderService productBrandOrder,
            IProductOrderCategorySubService productOrderCategorySubService,
            ICompanySerivice companySerivice) 
        {
            _orderProduct = orderProduct ?? throw new ArgumentNullException(nameof(orderProduct));
            _productOrderCategoryService = productOrderCategoryService ?? throw new ArgumentNullException(nameof(productOrderCategoryService));
            _productSpecificationService = productOrderSpecificationService ?? throw new ArgumentNullException(nameof(productOrderSpecificationService));
            _productOrderSpecificationDetailsService = productOrderSpecificationDetailsService ?? throw new ArgumentNullException(nameof(productOrderSpecificationDetailsService));
            _productOrderImageService = productOrderImageService ?? throw new ArgumentNullException(nameof(productOrderImageService));
            _productOrderCategorySubService = productOrderCategorySubService ?? throw new ArgumentNullException(nameof(productOrderCategorySubService));
            _productBrandOrder = productBrandOrder ?? throw new ArgumentNullException(nameof(productBrandOrder));
            _companySerivice = companySerivice ?? throw new ArgumentNullException(nameof(companySerivice));
        }



        public ActionResult ProductBySpecification(int id)
        {
            return View();
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

        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            ShopingCartService cart = ShopingCartService.GetCart(HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }


        // GET: Product
        public async Task<ActionResult> Index(string category, int categoryId, string brand, string specification, string specificationId, int id = 1)
        {
            if (TempData["category"] != null)
            {
                TempData.Remove("categoryId");

                TempData.Remove("category");
                TempData.Add("categoryId", categoryId);
                TempData.Add("category", category);
            }
            else if (!string.IsNullOrEmpty(category))
            {
                TempData.Add("categoryId", categoryId);

                TempData.Add("category", category);
            }
            if (TempData["brand"] != null)
            {
                TempData.Remove("brand");
                TempData.Add("brand", brand);
            }
            else if (!string.IsNullOrEmpty(brand))
            {
                TempData.Add("brand", brand);
            }
            if (TempData["specificationId"] != null)
            {
                TempData.Remove("specificationId");
                TempData.Add("specificationId", specification);
            }
            else if (!string.IsNullOrEmpty(specification))
            {

                TempData.Add("specificationId", specification);
            }

            ProductCategoryViewModel getCategory = await _productOrderCategorySubService.GetProductCategorySubCategory(category);


            if (!string.IsNullOrEmpty(category))
            {
                if (!string.IsNullOrEmpty(category) && id != 1)
                {
                    return await NewMethod(getCategory.Id.ToString(), brand, specification, id);
                }
                else if (!string.IsNullOrEmpty(category) & !string.IsNullOrEmpty(specification))
                {
                    if (!string.IsNullOrEmpty(category) & !string.IsNullOrEmpty(brand) & !string.IsNullOrEmpty(specification))
                    {
                        PageViewModel resultProductWithBrandAndSpecification = new PageViewModel
                        {
                            ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                            OrderProduct = await _orderProduct.OrderProduct(id),
                            ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                            SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                            Specification = await _productSpecificationService.ProductSpecification(getCategory.Id.ToString()),
                        };

                        return View(resultProductWithBrandAndSpecification);
                    }
                    var specId = Convert.ToInt32(specificationId);
                    PageViewModel resultWithSpecification = new PageViewModel
                    {
                        ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                        OrderProduct = await _orderProduct.OrderProduct(id, categoryId, specId),
                        ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                        SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                        Specification = await _productSpecificationService.ProductSpecification(getCategory.Id.ToString()),
                    };

                    return View(resultWithSpecification);
                }
                else if (!string.IsNullOrEmpty(category) & !string.IsNullOrEmpty(brand))
                {
                    ProductBrandViewModel getBrand = _productBrandOrder.GetBrandByName(brand);
                    if (!string.IsNullOrEmpty(category) & !string.IsNullOrEmpty(brand) & !string.IsNullOrEmpty(specification))
                    {
                        PageViewModel resultProductWithBrandAndSpecification = new PageViewModel
                        {
                            ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                            OrderProduct = await _orderProduct.OrderProduct(id),
                            ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                            SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                            Specification = await _productSpecificationService.ProductSpecification(getCategory.Id.ToString()),
                        };

                        return View(resultProductWithBrandAndSpecification);
                    }
                    PageViewModel resultWithSpecification = new PageViewModel
                    {
                        ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                        OrderProduct = await _orderProduct.OrderProduct(id, getCategory.Id, getBrand.Id),
                        ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                        SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                        Specification = await _productSpecificationService.ProductSpecification(getCategory.Id.ToString()),
                    };

                    return View(resultWithSpecification);
                }
                PageViewModel resultWithCategory = new PageViewModel
                {
                    ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                    OrderProduct = await _orderProduct.OrderProduct(id, categoryId),
                    ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                    SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                    Specification = await _productSpecificationService.ProductSpecification(getCategory.Id.ToString()),
                };

                return View(resultWithCategory);
            }


            return View();
        }

        private async Task<ActionResult> NewMethod(string category, string brand, string specification, int id)
        {
            if (!string.IsNullOrEmpty(category) && id != 1 & !string.IsNullOrEmpty(brand))
            {

                if (!string.IsNullOrEmpty(category) & id != 1 & !string.IsNullOrEmpty(brand) & !string.IsNullOrEmpty(specification))
                {
                    PageViewModel resultWithBrandAndSpecification = new PageViewModel
                    {
                        ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                        OrderProduct = await _orderProduct.OrderProduct(id),
                        ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                        SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                        Specification = await _productSpecificationService.ProductSpecification(category),
                    };

                    return View(resultWithBrandAndSpecification);
                }
                PageViewModel resultWithBrand = new PageViewModel
                {
                    ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                    OrderProduct = await _orderProduct.OrderProduct(id),
                    ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                    SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                    Specification = await _productSpecificationService.ProductSpecification(category),
                };

                return View(resultWithBrand);
            }
            if (!string.IsNullOrEmpty(category) & id != 1 & !string.IsNullOrEmpty(specification))
            {
                PageViewModel resultWithBrandAndSpecification = new PageViewModel
                {
                    ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                    OrderProduct = await _orderProduct.OrderProduct(id),
                    ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                    SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                    Specification = await _productSpecificationService.ProductSpecification(category),
                };

                return View(resultWithBrandAndSpecification);
            }
            PageViewModel resultWithCategoryWithPaged = new PageViewModel
            {
                ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                OrderProduct = await _orderProduct.OrderProduct(id),
                ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),
                Specification = await _productSpecificationService.ProductSpecification(category),
            };

            return View(resultWithCategoryWithPaged);
        }

        private async Task<PageViewModel> PageProductView(int id)
        {
            return new PageViewModel
            {
                ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                OrderProduct = await _orderProduct.OrderProduct(id),
                ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationDetail(),

            };
        }

        public async Task<ActionResult> GetById(string id)
        {
            var getSingleProduct = await _orderProduct.SingleProduct(id);
            //Task<ProductSingleViewModel> SingleProduct(string name);
            PageViewModel page = new PageViewModel
            {

                ListBrandByProduct = _productBrandOrder.GetTopBrand(),
                GetProductById = await _orderProduct.SingleProduct(id),
                OrderProduct = await _orderProduct.OrderProduct(Convert.ToInt32(id)),
                ListAllCategoryWithSubCategory = await _productOrderCategoryService.ListAllCategoryWithSubCategory(),
                SpecificationDetails = await _productOrderSpecificationDetailsService.ListProductSpecificationByProductName(getSingleProduct.Id),
                Specification = await _productSpecificationService.ListProductSpecificationByProductName(Convert.ToInt32(id)),
                ProductImage = await _productOrderImageService.ListProductImageByProductName(Convert.ToInt32(id)),
            };

            return View(page);
        }



        public ActionResult ProductSpecification()
        {
            return PartialView();
        }

        public ActionResult GetProductSpeficationDetails(IEnumerable<ProductSpecificationManageViewModel> Specification)
        {
            int item = Specification.Select(x => x.Id).FirstOrDefault();

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

        public ActionResult PriceRange()
        {
            return Redirect("/");
        }



        public ActionResult BottomSideBar()
        {
            return PartialView();
        }


    }
}