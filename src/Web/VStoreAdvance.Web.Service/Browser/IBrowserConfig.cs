using HostingStore.ProductService;

namespace VStoreAdvance.Web.Service.Browser
{
    public interface IBrowserConfig
    {
        ICacheService Cache { get; set; }
    }
}
