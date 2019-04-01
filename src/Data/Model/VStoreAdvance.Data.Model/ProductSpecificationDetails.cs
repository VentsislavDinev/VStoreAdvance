using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostingStore.Products
{
    public class ProductSpecificationDetail : Entity
    {
        private ICollection<ProductSubCategory> _specificationDetail;
        private ICollection<Product> _product;
        public ProductSpecificationDetail()
        {
            this._specificationDetail = new HashSet<ProductSubCategory>();
            this._product = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
      
        public int? ProductSubCategoryId { get; set; }
        public virtual ICollection<ProductSubCategory> ProductSubCategory
        {
            get
            {
                return this._specificationDetail;
            }

            set
            {
                this._specificationDetail = value;
            }
        }

        public int? ProductSpecificationId { get; set; }
        public virtual ProductSpecification ProductSpecification { get; set; }
    
        public int? ProductId { get; set; }
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

    }
}