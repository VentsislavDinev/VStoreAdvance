﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.ProductViewModel;

namespace HostingStore.ProductService
{
    public interface IProductOrderImageService : IApplicationService
    {
       Task<IEnumerable<ProductImageListViewModel>> ListProductImage();
       Task<IEnumerable<ProductImageListViewModel>> ListProductImageByProductName(int productId);
       Task<IEnumerable<ProductImageListViewModel>> ListProductImageByProductName(int productId, int id);
       Task<IList<ProductImageListViewModel>> SingleProductImageByProductName(string productId);
    }
}