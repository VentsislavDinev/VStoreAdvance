using Abp.Application.Services;
using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductOrderSpecificationDetailsService : ApplicationService, IProductOrderSpecificationDetailsService
    {
        private IProductSpecificationDetailService _productSpecificationService;

        public ProductOrderSpecificationDetailsService(IProductSpecificationDetailService productSpecificationService)
        {
            _productSpecificationService = productSpecificationService ?? throw new ArgumentNullException(nameof(productSpecificationService));
        }

        public async Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationByProductName(int productId, int id)
        {

            List<ProductSpecificationDetailManageViewModel> getProductSpecification = await _productSpecificationService.GetAll().Where(x => x.ProductId == productId & x.ProductSpecificationId == id)
                .Select(x => new ProductSpecificationDetailManageViewModel
                {
                    ProductId =     x.ProductId,
                    SpecificationDetailId = x.Id,
                    Id = x.ProductSpecificationId,
                    Name = x.Name,
                    Description = x.Description,
                }).ToListAsync();
            return getProductSpecification;

        }

        public async Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationByProductName(int productId)
        {
            List<ProductSpecificationDetailManageViewModel> getProductSpecification = await  _productSpecificationService.GetAll().Where(x => x.ProductId == productId)
                  .Select(x => new ProductSpecificationDetailManageViewModel
                  {
                     
                      ProductId = x.ProductId,
                      SpecificationDetailId = x.Id,
                      Id = x.ProductSpecificationId,
                      Name = x.Name,
                      Description = x.Description,
                  }).ToListAsync();
            return getProductSpecification;
        }

        public async Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecification(int productId)
                        {
            List<ProductSpecificationDetailManageViewModel> getProductSpecification = await _productSpecificationService
                .GetAll()
                .Where(x => x.ProductSpecificationId == productId & x.ProductId == 0 || x.ProductId == null)
                .Select(x => new ProductSpecificationDetailManageViewModel
                {
                    ProductId = x.ProductId,
                    SpecificationDetailId = x.Id,
                    Id = x.ProductSpecificationId,
                    Name = x.Name,
                    Description = x.Description,
                }).ToListAsync();
            return getProductSpecification;
        }


        public IEnumerable<ProductSpecificationDetailManageViewModel> ListProductSpecificationNotAsync(int productId)
        {
            List<ProductSpecificationDetailManageViewModel> getProductSpecification =  _productSpecificationService
                .GetAll()
                .Where(x => x.ProductSpecificationId == productId & x.ProductId == 0 || x.ProductId == null)
                .Select(x => new ProductSpecificationDetailManageViewModel
                {
                    ProductId = x.ProductId,
                    SpecificationDetailId = x.Id,
                    Id = x.ProductSpecificationId,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList();
            return getProductSpecification;
        }


        public async Task<IEnumerable<ProductSpecificationDetailManageViewModel>> ListProductSpecificationBySpecificationId(int productId)
        {
            List<ProductSpecificationDetailManageViewModel> getProductSpecification = await _productSpecificationService.GetAll().Where(x => x.ProductSpecificationId == productId)
                  .Select(x => new ProductSpecificationDetailManageViewModel
                  {
                      ProductId = x.ProductId,
                      SpecificationDetailId = x.Id,
                      Id = x.ProductSpecificationId,
                      Name = x.Name,
                      Description = x.Description,
                  }).ToListAsync();
            return getProductSpecification;
        }

        public IEnumerable<ProductSpecificationDetailManageViewModel> ListProductSpecificationDetail()
        {

            List<ProductSpecificationDetailManageViewModel> getProductSpecification = _productSpecificationService.GetAll()
                .Where(x=>x.ProductId == 0 | x.ProductId == null)
                .Select(x => new ProductSpecificationDetailManageViewModel
                {
                    ProductId = x.ProductId,
                    SpecificationDetailId = x.Id,
                    Id = x.ProductSpecificationId,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList();
            return getProductSpecification;

        }

        public async Task<IList<ProductSpecificationDetailManageViewModel>> SingleProductSpecificationByProductName(string productId)
        {

            List<ProductSpecificationDetailManageViewModel> getProductSpecification = await _productSpecificationService.GetAll().Where(x => x.Name == productId)
                .Select(x => new ProductSpecificationDetailManageViewModel
                {
                    SpecificationDetailId = x.Id,
                    Id = x.ProductSpecificationId,
                    Name = x.Name,
                    Description = x.Description,
                }).ToListAsync();
            return getProductSpecification;

        }
    }
}
