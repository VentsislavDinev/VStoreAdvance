using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductViewModel
{
    public class ProductReviewManageViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
    }
}
