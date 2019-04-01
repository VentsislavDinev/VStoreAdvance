
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VStoreAdvance.Data.EntityFramework;

namespace HostingStore.ProductService
{
    public class DropdownListPopulator : ApplicationService, IDropdownListPopulator
    {
        private ICacheService cache;
        private VStoreAdvanceDbContext _data;

        public DropdownListPopulator(ICacheService cache)
        {
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public IEnumerable<SelectListItem> GetSubCategories()
        {

            var categories = this.cache.Get<IEnumerable<SelectListItem>>("categories",
                () =>
                {
                    return this._data.ProductSubCategories
                      
                       .Where(x => x.ProductID == 0 || x.ProductID == null)
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Category
                       })
                       .ToList();
                });

            return categories;
        }


        public IEnumerable<SelectListItem> GetImages()
        {

            var categories = this.cache.Get<IEnumerable<SelectListItem>>("image",
                () =>
                {
                    return this._data.ProductBrands
                       
                       .Where(x => x.ProductId == 0 || x.ProductId == null)
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                });

            return categories;
        }



        public IEnumerable<SelectListItem> GetSpecification()
        {

            var categories = this.cache.Get<IEnumerable<SelectListItem>>("specification",
                () =>
                {
                    return this._data.ProductSpecifications
                       
                       .Where(x => x.ProductId == 0 || x.ProductId == null)
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                });

            return categories;
        }

        public IEnumerable<SelectListItem> GetSpecificationDetail()
        {

            var categories = this.cache.Get<IEnumerable<SelectListItem>>("specificationDetails",
                () =>
                {
                    return this._data.ProductSpecificationDetails
                      
                       .Where(x => x.ProductId == 0 || x.ProductId == null)
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                });

            return categories;
        }
    }
}
