using Abp.Domain.Entities;
using System.Collections.Generic;

namespace HostingStore.Products
{
    public class ProductSpecification : Entity
    {
        private ICollection<ProductSpecificationDetail> blogPostAnswer;
   private ICollection<ProductSubCategory> _productSubCategories;
     

        public ProductSpecification()
        {
            this.blogPostAnswer = new HashSet<ProductSpecificationDetail>();
            this._productSubCategories = new HashSet<ProductSubCategory>();
   
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AnswerId { get; set; }
        public Answer? Answer { get; set; }
        
        public int? ProductSpecificationDetailId { get; set; }
        public ICollection<ProductSpecificationDetail> ProductSpecificationDetails
        {
            get
            {
                return this.blogPostAnswer;
            }
            set
            {
                this.blogPostAnswer = value;
            }
        }

        
        public int ProductSubCateoryId { get; set; }

        public virtual ProductSubCategory ProductSubCategory { get; set; }
        
        
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
