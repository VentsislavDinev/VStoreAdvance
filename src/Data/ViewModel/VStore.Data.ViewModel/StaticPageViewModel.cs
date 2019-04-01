namespace VAgency.Data.ViewModels
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class StaticPageViewModel
    {
        public StaticPageViewModel()
        {
        }

        public int Id { get; set; }

       public string Name { get; set; }

       [AllowHtml]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime CreatedOn { get; set; }
    }
}