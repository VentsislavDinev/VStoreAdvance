using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostingStore.Products
{
    public class ProductSubCategory : Entity
    {
        private ICollection<ProductSpecification> _specification;
        private ICollection<Product> _product;

        public ProductSubCategory()
        {

            this._specification = new HashSet<ProductSpecification>();

            this._product = new HashSet<Product>();

        }
        public int Id { get; set; }
        public string Category { get; set; }
        public int ProductCategoryID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public int? ProductID { get; set; }
        public virtual ICollection<Product> Product
        {
            get
            {
                return this._product;
            }

            set
            {
                this._product = value;
            }
        }


        public int ProductSpecificationId { get; set; }
        public virtual ICollection<ProductSpecification> Specification
        {
            get
            {
                return this._specification;
            }

            set
            {
                this._specification = value;
            }
        }
    }
}