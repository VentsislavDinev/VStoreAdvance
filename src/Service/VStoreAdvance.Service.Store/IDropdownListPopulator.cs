using Abp.Application.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HostingStore.ProductService
{
    public interface IDropdownListPopulator : IApplicationService
    {
        IEnumerable<SelectListItem> GetSpecification();
        IEnumerable<SelectListItem> GetSpecificationDetail();
        IEnumerable<SelectListItem> GetSubCategories();
        IEnumerable<SelectListItem> GetImages();
    }
}