using System;

namespace HostingStore.ProductService
{
    public interface ICacheService
    {
        T Get<T>(string cacheID, Func<T> getItemCallback) where T : class;

        void Clear(string cacheId);
    }
}