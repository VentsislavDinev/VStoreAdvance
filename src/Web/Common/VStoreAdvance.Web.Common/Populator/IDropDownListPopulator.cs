using System.Collections.Generic;
using System.Web.Mvc;
using Abp.Application.Services;

namespace VStoreAdvance.Web.Common.Populator
{
    public interface IDropDownListPopulator : IApplicationService
    {
        IEnumerable<SelectListItem> GetBlogCategories();
        IEnumerable<SelectListItem> GetCoursesCategories();
    }
}