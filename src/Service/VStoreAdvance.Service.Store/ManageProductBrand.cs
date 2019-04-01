using HostingStore.ProductViewModel;
using System;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ManageProductBrand : IManageProductBrand
    {
        private readonly IProductBrandService _productBrand;

        public ManageProductBrand(IProductBrandService productBrand)
        {
            _productBrand = productBrand ?? throw new ArgumentNullException(nameof(productBrand));
        }

        public async Task Create(ProductBrandViewModel model)
        {
            await _productBrand.Create(model.Name, model.Description, model.Image);
        }
        public async Task Update(ProductBrandViewModel model)
        {
            await _productBrand.Update(model.Name, model.Description, model.Image);
        }
        public async Task Delete(ProductBrandViewModel model)
        {
            await _productBrand.Delete(model.Name, model.Description, model.Image);
        }


    }
}
