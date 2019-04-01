using System;
using System.Web;

namespace HostingStore.ProductViewModel
{
    public class ProductImageListViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProductId { get; set; }
        public string Avatar { get; set; }
    }
}
