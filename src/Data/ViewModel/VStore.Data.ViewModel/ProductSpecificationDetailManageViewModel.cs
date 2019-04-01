using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HostingStore.ProductViewModel
{
    public class ProductSpecificationDetailManageViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecificationName { get; set; }
        public int SpecificationDetailId { get; set; }
        public int SubCategoryId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string Avatar { get; set; }
        [Display(Name = "Category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }

        public int Specification { get; set; }
        public IEnumerable<SelectListItem> SpecificationId { get; set; }
        public IEnumerable<SelectListItem> SpecificicationDetailId { get; set; }
    }
}
