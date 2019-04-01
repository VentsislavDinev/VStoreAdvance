using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HostingStore.ProductViewModel
{
    public class ProductManageViewModel
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? StartPromoPrice { get; set; }
        public TimeSpan? EndPromoPrice { get; set; }
        [Required(ErrorMessage = "Полето е задължително")]
        [Range(0.99, 99999, ErrorMessage = "Полето трябва да е между 0.99 и 9999")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
          public decimal Price { get; set; }
        public decimal? PromoPrice { get; set; }
        public string Brand { get; set; }
        public decimal? RealPrice { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(100, ErrorMessage = "полето трябва да е между 5 и 100 символа", MinimumLength = 5)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(10000, ErrorMessage = "Полето трябва да е между 1 и 10000 символа", MinimumLength = 1)]
        public string Description { get; set; }
        
        public HttpPostedFileBase Avatar { get; set; }
        public IEnumerable<SelectListItem> SpecificationId { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<SelectListItem> SpecificicationDetailId { get; set; }
        public IEnumerable<SelectListItem> BrandProduct { get; set; }
    }
}
