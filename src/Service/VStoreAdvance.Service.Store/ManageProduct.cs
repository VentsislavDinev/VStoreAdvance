using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageProduct : ApplicationService, IManageProduct
    {
        private IProductService _productService;

        public ManageProduct(IProductService productService)
        {
            this._productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task CreateProduct(ProductManageViewModel model, string file, ICollection<string> specification, 
            ICollection<string> category, ICollection<string> specificationDetail, ICollection<string> brands)
        {
            await this._productService.Create(model.Name, model.Description, model.RealPrice,
                model.Price, model.CreatedOn, model.StartPromoPrice, model.EndPromoPrice,
                model.PromoPrice, file, specification, category, 
                specificationDetail, brands);
        }
        //public async Task CreateParentProduct(ProductManageViewModel model, string file, int id, int categoryId,  int parentId)
        //{
        //    await this._productService.ParentCreate(model.Name, model.Description, model.RealPrice, model.Price, model.CreatedOn, model.StartPromoPrice, model.EndPromoPrice, model.PromoPrice, file, id, categoryId, parentId, model.Brand);
        //}


        public async Task UpdateProduct(ProductManageViewModel model, string file, int id, int categoryId)
        {
            await this._productService.Update(model.Name, model.Description, model.RealPrice, model.Price, model.CreatedOn, model.StartPromoPrice, model.EndPromoPrice, model.PromoPrice, file, id, categoryId, model.Brand);
        }


        public async Task DeleteProduct(ProductManageViewModel model, string file, int id, int categoryId)
        {
            await this._productService.Delete(model.Name, model.Description, model.RealPrice, model.Price, model.CreatedOn, model.StartPromoPrice, model.EndPromoPrice, model.PromoPrice, file, id, categoryId, model.Brand);
        }
    }
}
