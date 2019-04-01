using Abp.Application.Services;
using System;

namespace HostingStore.ProductService
{
    public interface ICacheService : IApplicationService
    {
        T Get<T>(string cacheID, Func<T> getItemCallback) where T : class;

        void Clear(string cacheId);
    }
}