using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
     public class ProductPromoHomeOrderService : IProductPromoHomeOrderService
    {
        private const int pageNumber = 100;
        private readonly IProductPromoHomeService _productPromoHome;
        public ProductPromoHomeOrderService(IProductPromoHomeService productPromoHome)
        {
            _productPromoHome = productPromoHome ?? throw new ArgumentNullException(nameof(productPromoHome));
        }

        public async Task<IList<ProductHomeServiceViewModel>> OrderProduct()
        {
            List<ProductHomeServiceViewModel> getAll = await _productPromoHome.GetAll()
              
                .OrderByDescending(x => x.Price)
                .Select(x => new ProductHomeServiceViewModel
                {
                     Price = x.Price,
                     Avatar = x.Avatar,
                     Description = x.Description,
                      Name = x.Name
                }).ToListAsync();

            return getAll;
        }
    }
}
