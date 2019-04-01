
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductPromoHomeService : IProductPromoHomeService
    {
        
        private readonly IRepository<ProductPromoHome> _productCategory;


        public ProductPromoHomeService(IRepository<ProductPromoHome> order)
        {
           _productCategory = order ?? throw new ArgumentNullException(nameof(order));

        }

        public async Task<ProductPromoHome> Create(string name, string desc, string avatar, double price)
        {
            ProductPromoHome newProduct = new ProductPromoHome
            {
                 Avatar = avatar, 
                  Description = desc,
                   Name = name,
                    Price = price,
            };

           await  _productCategory.InsertAsync(newProduct);
           
            return newProduct;
        }


        public async Task<ProductPromoHome> Update(string name, string desc, string avatar, double price)
        {
            ProductPromoHome newProduct = new ProductPromoHome
            {

                Avatar = avatar,
                Description = desc,
                Name = name,
                Price = price,
            };

            await _productCategory.UpdateAsync(newProduct);
    
            return newProduct;
        }


        public async Task<ProductPromoHome> Delete(string name, string desc, string avatar, double price)
        {
            ProductPromoHome newProduct = new ProductPromoHome
            {
                Avatar = avatar,
                Description = desc,
                Name = name,
                Price = price,
            };

             await _productCategory.DeleteAsync(newProduct);
           
            return newProduct;
        }

        public IQueryable<ProductPromoHome> GetAll()
        {
            return _productCategory.GetAll();
        }

        public IQueryable<ProductPromoHome> GetById(int id)
        {
            return this._productCategory.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<ProductPromoHome> GetByName(string code)
        {
            return this._productCategory.GetAll().Where(x => x.Name == code);
        }
    }
}
