using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostingStore.Products
{
    public class ProductBrand : Entity
    {
        private ICollection<Product> _product;
        public ProductBrand()
        {
            this._product = new HashSet<Product>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        [Column("Product_Id")]
        public int? ProductId { get; set; }
        public virtual ICollection<Product> Product
        {

            get
            {
                return this._product;
            }
            set
            {
                _product = value;
            }
        }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}