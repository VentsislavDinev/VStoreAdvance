using HostingStore.ProductService;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace VStyoreAdvace.Web.WebApi.Server.Controllers
{
    public class ProductController : ApiController
    {
        private IOrderProductList _orderProduct;

        // GET: Product
        public IList<ProductSingleViewModel> ListProductByBrand()
        {
            return _orderProduct.ListBrandByProduct();
        }

        public async Task<ProductSearchViewModel> OrderProductWtihCategory(int id, int categoryId)
        {
            return await _orderProduct.OrderProduct(id, categoryId);
        }

        public async Task<ProductSearchViewModel> OrderProductByBrand(int id, int categoryId, int brandId)
        {
            return await _orderProduct.OrderProduct(id, categoryId, brandId);
        }

        public async Task<ProductSearchViewModel> ProductSpecification(int id, int specifiId)
        {
            return await _orderProduct.OrderProductBySpecificationId(id, specifiId);
        }

        public async Task<ProductSearchViewModel> ProductBySpecification(int id, string categoryId)
        {
            return await _orderProduct.OrderProductByCategory(id, categoryId);
        }

        public async Task<ProductSingleViewModel> GetByName(string name)
        {
            return await _orderProduct.SingleProduct(name);
        }
    }
}