using System;
using System.ComponentModel.DataAnnotations;

namespace VAgency.Data.ViewModels.Company
{
    public class CompanyMessageCreateViewViewModel
    {
        public string Title { get; set; }

       public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public string Phone { get; set; }
  public string FirstName { get; set; }
  public string Email { get; set; }
 public string LastName { get; set; }
    }
}