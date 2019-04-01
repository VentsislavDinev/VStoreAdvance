using System.ComponentModel.DataAnnotations;

namespace VAgency.Data.ViewModels
{
    public class StaticPageURLViewModel
    {
        public StaticPageURLViewModel()
        {
        }

        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string URL { get; set; }

        public int ImageId { get; set; }

        //public virtual StaticPageUrlImage Image { get; set; }
    }
}