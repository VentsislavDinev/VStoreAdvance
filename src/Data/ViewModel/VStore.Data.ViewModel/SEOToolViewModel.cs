using System.Collections.Generic; 

namespace VAgency.Data.ViewModels.Company
{
    public  class SEOToolViewModel
    {  
        public string GoogleVerify { get; set; }
        public string YandexNumber { get; set; }
        public string SiteName { get; set; }
        public string SiteDescription { get; set; }
        public List<string> SiteLocalization { get; set; }
        public string MsValidator { get; set; }
        public string URL { get; set; }
        public string ImageName { get; set; }
        public string AppId { get; set; }
        public string Keyword { get; set; }
        public string GOogleAnalytics { get; set; }
    }
}
