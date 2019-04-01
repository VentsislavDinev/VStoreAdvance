using System.Web;

namespace VAgency.Data.ViewModels.Company
{
    public class CompanyImageViewModel
    {
        public string Name { get; set; }
        public HttpPostedFileBase Upload { get; set; }
    }
}