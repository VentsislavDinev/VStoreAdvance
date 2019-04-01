using System;
using System.Web;

namespace HostingStore.ProductViewModel
{
    public class ProductImageManageViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProductId { get; set; }
    }
}
