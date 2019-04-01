using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HostingStore.ProductViewModel
{
    public  class ProductBrandViewModel
    {
        public string Name { get; set; }
        public HttpPostedFileBase Avatar { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
