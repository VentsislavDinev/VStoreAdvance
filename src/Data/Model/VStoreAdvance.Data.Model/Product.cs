using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.Products
{
    public class Product : Entity, IEntity<int>
    {
        
        private ICollection<ProductSpecification> _productSpecification;
        private ICollection<ProductCategory> _productCategories;
        private ICollection<ProductSubCategory> _productSubCategories;
        private ICollection<ProductSpecificationDetail> _productSpecificationDetails;
        private ICollection<ProductImage> _productImage;
        private ICollection<ProductBrand> _productBrand;

        public Product()
        {
            this._productSpecification = new HashSet<ProductSpecification>();
            this._productCategories = new HashSet<ProductCategory>();
            this._productSubCategories = new HashSet<ProductSubCategory>();
            _productSpecificationDetails = new HashSet<ProductSpecificationDetail>();
            this._productImage = new HashSet<ProductImage>();
            this._productBrand = new HashSet<ProductBrand>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Keyword { get; set; }
        public string ShortContent { get; set; }
        public string Description { get; set; }
        public int? ProductCategoryId { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory
        {

            get
            {
                return this._productCategories;
            }
            set
            {
                _productCategories = value;
            }
        }


        public int? ProductSingleBrandId { get; set; }
        public virtual ProductBrand ProductSingleBrand { get; set; }

        public int? ProductBrandId { get; set; }
        public virtual ICollection<ProductBrand> ProductBrand
        {

            get
            {
                return this._productBrand;
            }
            set
            {
                _productBrand = value;
            }
        }


        public int ProductSubCategoryId { get; set; }
        public virtual ICollection<ProductSubCategory> ProductSubCategory { get
            {
                return _productSubCategories;
            }
            set
            {
                _productSubCategories = value;
            }
        }
        public int ProductSpecificationDetailId { get; set; }
        public virtual ICollection<ProductSpecificationDetail> ProductSpecificationDetail
        {
            get
            {
                return _productSpecificationDetails;
            }
            set
            {
                _productSpecificationDetails = value;
            }
        }
        //public int ProductSubCategoryId { get; set; }
        //public ProductSubCategory ProductSubCategory { get; set; }


        public int? ProductSpecificationSingleId { get; set; }
        public virtual ProductSpecification ProductSpecificationSingle { get; set; }
        public int ProductSpecificationId { get; set; }
        public virtual ICollection<ProductSpecification> ProductSpecification
        {
            get
            {
                return this._productSpecification;
            }

            set
            {
                this._productSpecification = value;
            }
        }

      
        //public int ProductSubParrentCategoryId { get; set; }
        //public ProductSubParrentCategory ProductSubParrentCategory { get; set; }
        //public int ProductReviewId { get; set; }
        //public virtual IEnumerable<ProductReview> ProductReview { get; set; }

        public int ProductImageId { get; set; }
        public virtual ICollection<ProductImage> ProductImage
        {
            get
            {
                return this._productImage;
            }

            set
            {
                this._productImage = value;
            }
        }

        public DateTime? CreatedOn { get; set; }
        public DateTime? StartPromoPrice { get; set; }
        public TimeSpan? EndPromoPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PromoPrice { get; set; }

        public decimal? RealPrice { get; set; }
        public string Avatar { get; set; }
    }
}
