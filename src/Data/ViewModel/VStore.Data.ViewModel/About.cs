namespace VAgency.Data.ViewModels
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class AboutViewModel
    {
        public AboutViewModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [AllowHtml]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime CreationTime { get; set; }
    }
}