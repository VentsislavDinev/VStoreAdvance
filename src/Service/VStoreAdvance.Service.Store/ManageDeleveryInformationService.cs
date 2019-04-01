using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageDeleveryInformationService : IManageDeleveryInformationService
    {

        private IDeleveryInformationService _productService;

        public ManageDeleveryInformationService(IDeleveryInformationService productService)
        {
            this._productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task CreateProduct(DeleveryInformationViewModel model)
        {
            await this._productService.Create(model.Address, model.City, model.Country, model.StreetNumber, model.FirstName, model.LastName, model.Phone);
        }
        //public async Task CreateParentProduct(ProductManageViewModel model, string file, int id, int categoryId,  int parentId)
        //{
        //    await this._productService.ParentCreate(model.Name, model.Description, model.RealPrice, model.Price, model.CreatedOn, model.StartPromoPrice, model.EndPromoPrice, model.PromoPrice, file, id, categoryId, parentId, model.Brand);
        //}


        public async Task UpdateProduct(DeleveryInformationViewModel model)
        {
            await this._productService.Update(model.Address, model.City, model.Country, model.StreetNumber, model.FirstName, model.LastName, model.Phone);
        }


        public async Task DeleteProduct(DeleveryInformationViewModel model)
        {
            await this._productService.Delete(model.Address, model.City, model.Country, model.StreetNumber, model.FirstName, model.LastName, model.Phone);
        }
    }
}
