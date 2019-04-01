using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductViewModel
{
    public class ProductSearchViewModel
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<ProductCatalogViewModel> Space { get; set; }
        public List<ProductCatalogViewModel> ProductFilter { get; set; }
    }
}
