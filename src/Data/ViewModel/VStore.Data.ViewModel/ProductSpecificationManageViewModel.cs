using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductViewModel
{
    public class ProductSpecificationManageViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductId { get; set; }

        public int SpecificationDetailId { get; set; }
        public int Id { get; set; }

        [Display(Name = "Category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Category { get; set; }
    }
}
