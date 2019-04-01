using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
     public class ProductPromoHomeOrderService : ApplicationService, IProductPromoHomeOrderService
    {
        private const int pageNumber = 100;
        private readonly IProductPromoHomeService _productPromoHome;
        public ProductPromoHomeOrderService(IProductPromoHomeService productPromoHome)
        {
            _productPromoHome = productPromoHome ?? throw new ArgumentNullException(nameof(productPromoHome));
        }

        public IList<ProductHomeServiceViewModel> OrderProduct()
        {
            List<ProductHomeServiceViewModel> getAll =  _productPromoHome.GetAll()
              
                .OrderByDescending(x => x.Price)
                .Select(x => new ProductHomeServiceViewModel
                {
                     Price = x.Price,
                     Avatar = x.Avatar,
                     Description = x.Description,
                      Name = x.Name
                }).ToList();

            return getAll;
        }
    }
}
