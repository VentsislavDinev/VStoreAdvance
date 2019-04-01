//using Abp.Application.Services;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using VStoreAdvance.Data.EntityFramework;
//using VStoreAdvance.Web.Common.Populator;

//namespace VEducation.Web.Common.Populator
//{
//    public class DropDownListPopulator : ApplicationService, IDropDownListPopulator
//    {
//        private VStoreAdvanceDbContext _blog;
       
//        public VStoreAdvanceDbContext Blog { get => _blog; set => _blog = value; }

//        public DropDownListPopulator(VStoreAdvanceDbContext data)
//        {
//            Blog = data ?? throw new System.ArgumentNullException(nameof(data));
//        }

//        public IEnumerable<SelectListItem> GetBlogCategories()
//        {

//            return Blog.BlogPostCategories
//               .Select(c => new SelectListItem
//               {
//                   Value = c.Id.ToString(),
//                   Text = c.Name
//               })
//               .ToList();
//        }

//        public IEnumerable<SelectListItem> GetCoursesCategories()
//        {

//            return Blog.CoursesCategories
//               .Select(c => new SelectListItem
//               {
//                   Value = c.Id.ToString(),
//                   Text = c.Name
//               })
//               .ToList();

//        }
//    }
//}
