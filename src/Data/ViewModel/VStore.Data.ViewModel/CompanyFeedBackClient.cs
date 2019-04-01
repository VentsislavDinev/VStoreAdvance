namespace VAgency.Data.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CompanyFeedBackClientViewModel
    {

        public CompanyFeedBackClientViewModel()
        {

        }

        public int Id { get; set; }

        [DataType(DataType.Text)]
       public string Name { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        public string WorkInCompany { get; set; }

        [DataType(DataType.Text)]
         public string CompanyPosition { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime CreationTime { get; set; }
    }
}