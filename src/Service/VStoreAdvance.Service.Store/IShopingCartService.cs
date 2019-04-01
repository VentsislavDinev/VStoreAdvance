using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using hostingstore.productservice;
using HostingStore.Products;

namespace HostingsStore.ProductService
{
    public interface IShopingCartService
    {
        //ShopingCartService GetCart(Controller controller);
        void AddToCart(Product album);
        int CreateOrder(Order order);
        void EmptyCart();
        string GetCartId(HttpContextBase context);
        List<Cart> GetCartItems();
        int GetCount();
        decimal GetTotal();
        void MigrateCart(string userName);
        int RemoveFromCart(int id);
    }
}