using System;
using System.ComponentModel.DataAnnotations;

namespace VAgency.Data.ViewModels
{
    public class CompanyContactViewModel
    {
        public CompanyContactViewModel()
        {
        }

        public int Id { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phonenumber { get; set; }
 public string OfficeCountry { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime WorkFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime WorkTo { get; set; }

         public string City { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Text)]
        public string Email { get; set; }
        public string OfficeAddress { get; set; }
    }
}