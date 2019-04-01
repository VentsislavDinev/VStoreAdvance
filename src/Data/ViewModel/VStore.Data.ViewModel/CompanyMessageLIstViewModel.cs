using System.Collections.Generic;

namespace VAgency.Data.ViewModels.Company
{
    public class CompanyMessageLIstViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        //public int MaxPage { get; set; }
        //public int PreviosPage { get; set; }
        public IEnumerable<CompanyMessageViewViewModel> CompanyMessage { get; set; }
    }
}