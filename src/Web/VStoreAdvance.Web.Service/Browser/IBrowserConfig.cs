using Abp.Application.Services;
using HostingStore.ProductService;

namespace VStoreAdvance.Web.Service.Browser
{
    public interface IBrowserConfig: IApplicationService
    {
        ICacheService Cache { get; set; }
    }
}
