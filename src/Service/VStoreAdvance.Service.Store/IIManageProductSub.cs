﻿using HostingStore.ProductViewModel;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public interface IManageProductSub
    {
        Task CreateProduct(ProductCategoryViewModel model, string id);
        Task DeleteProduct(ProductCategoryViewModel model, string id);
        Task UpdateProduct(ProductCategoryViewModel model, string id);
    }
}