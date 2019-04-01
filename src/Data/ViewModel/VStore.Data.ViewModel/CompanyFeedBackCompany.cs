namespace VAgency.Data.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CompanyFeedBackCompanyViewModel
    {
        public CompanyFeedBackCompanyViewModel()
        {
        }

        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        [DataType(DataType.MultilineText)]
      public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime CreationTime { get; set; }

        public int CompanyLogoId { get; set; }

        public string CompanyLogos { get; set; }
    }
}