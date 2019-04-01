using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;

namespace HostingStore.ProductViewModel
{
    public class PageViewModel
    {
        public ProductSearchViewModel OrderProduct { get; set; }
        public List<ProductBrandViewModel> ListBrandByProduct { get; set; }
        public IList<ProductCategoryViewModel> ListAllCategoryWithSubCategory { get; set; }
        public IEnumerable<ProductSpecificationDetailManageViewModel> ProductDetails { get; set; }
        public IEnumerable<ProductSpecificationDetailManageViewModel> SpecificationDetails { get; set; }
        public IEnumerable<ProductSpecificationManageViewModel> Specification { get; set; }
        public ProductSingleViewModel GetProductById { get; set; }
        public IEnumerable<ProductImageListViewModel> ProductImage { get; set; }
        public IList<ProductSpecificationManageViewModel> ProductSpecification { get; set; }
        public IList<ProductSingleViewModel> ListProductBrand { get; set; }
        public IList<ProductHomeServiceViewModel> ProductPromoHome { get; set; }
        public LoginViewModel Login { get; set; }
        public CompanyContactViewModel Contact { get; set; }
        public List<StaticPageViewModel> StaticPage { get; set; }
        public RegisterViewModel Register { get; set; }
        public DeleveryInformationViewModel DeleveryInformation { get; set; }

        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "град")]
        public string City { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "държава")]
        public string Country { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Номер")]
        public string StreetNumber { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        public ShoppingCartViewModel ShoppingCart { get; set; }
        public StaticPageViewModel GetSingleStaticPage { get; set; }
    }
}
