using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductImageList : ApplicationService, IProductImageList
    {
        private const int pageNumber = 10;

        private IProductImageService _productImage;

        public ProductImageList(IProductImageService productImage)
        {
            _productImage = productImage ?? throw new ArgumentNullException(nameof(productImage));
        }

        public ProductImagehViewModel ListProductImage(int id)
        {
            var page = id;
            var allItemCount = this._productImage.GetAll().Count();
            var totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            var itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;

            var getAll = _productImage.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new ProductImageListViewModel
                {
                     CreatedOn = x.CreatedOn,
                     Avatar = x.File,
                      ProductId = x.ProductId,
                }).ToList();
            var searchEmpty = new ProductImagehViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };


            return searchEmpty;
        }
        
        public ProductImageListViewModel GetSingleProductImage(string id)
        {
            var getProductSpecification = _productImage.GetByProductId(Convert.ToInt32(id))
           .Select(x => new ProductImageListViewModel
           {
               Avatar = x.File,
           }).FirstOrDefault();
            return getProductSpecification;
        }

        public ProductImageListViewModel GetSingleProductImage(int id)
        {
            var getAll = _productImage.GetById(id)
                .Select(x => new ProductImageListViewModel
                {
                     CreatedOn = x.CreatedOn,
                     Avatar = x.File,
                     ProductId = x.ProductId
                })
                .FirstOrDefault();

            return getAll;
        }


        //public ProductSingleViewModel SingleProduct(string name)
        //{
        //    var getAll = _productService.GetByName(name)
        //       .Select(x => new ProductSingleViewModel
        //       {
        //           Name = x.Name,
        //           Description = x.Description,
        //           Price = x.Price,
        //           Avatar = x.Avatar,
        //           EndPromoPrice = x.EndPromoPrice,
        //           PromoPrice = x.PromoPrice,
        //           RealPrice = x.RealPrice,
        //           StartPromoPrice = x.StartPromoPrice,
        //       })
        //       .SingleOrDefault();
        //    return getAll;
        //}
        //public ProductSearchViewModel OrderProduct(int id)
        //{
        //    var page = id;

        //    var allItemCount = this._productService.GetAll().Count();
        //    var totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
        //    var itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;

        //    var getAll = _productService.GetAll()
        //        .OrderByDescending(x => x.CreatedOn)
        //        .Skip(itemToSkipFromDb)
        //        .Take(pageNumber)
        //        .Select(x => new ProductCatalogViewModel
        //        {
        //            Name = x.Name,
        //            Description = x.Description,
        //            Price = x.Price,
        //            Avatar = x.Avatar,
        //        });
        //    var searchEmpty = new ProductSearchViewModel
        //    {

        //        TotalPages = totalPagesFromDb,
        //        CurrentPage = page,
        //        Space = getAll,
        //    };
        //    return searchEmpty;
        //}

    }
}
