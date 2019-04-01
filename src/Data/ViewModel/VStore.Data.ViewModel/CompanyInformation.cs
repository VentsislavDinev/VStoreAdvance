using System.ComponentModel.DataAnnotations;
using System.Web;
namespace VAgency.Data.ViewModels
{
    public class CompanyInformationViewViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public HttpPostedFileBase Upload { get; set; }
    }
}