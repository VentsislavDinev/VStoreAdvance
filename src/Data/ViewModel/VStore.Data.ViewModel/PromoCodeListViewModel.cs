using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductViewModel
{
    public class PromoCodeListViewModel
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public IQueryable<PromoCodeViewModel> Space { get; set; }
    }
}
