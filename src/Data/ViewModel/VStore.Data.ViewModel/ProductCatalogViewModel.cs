using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductViewModel
{
    public class ProductCatalogViewModel
    {

        public DateTime CreatedOn { get; set; }
        public DateTime StartPromoPrice { get; set; }
        public TimeSpan EndPromoPrice { get; set; }
        public decimal Price { get; set; }
        public decimal PromoPrice { get; set; }

        public decimal RealPrice { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Keyword { get; set; }
    }
}
