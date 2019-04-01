using System.Web;


namespace VAgency.Data.ViewModels
{
    public class CompanyLogoVieModel
    {                                           
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public HttpPostedFileBase Upload { get; set; }
    }
}