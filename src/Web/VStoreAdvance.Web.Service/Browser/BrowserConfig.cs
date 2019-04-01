using HostingStore.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VStoreAdvance.Web.Service.Browser
{
    public class BrowserConfig : IBrowserConfig
    {
        private ICacheService _cache;

        public BrowserConfig(ICacheService cache)
        {
            Cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public ICacheService Cache { get => _cache; set => _cache = value; }

    }
}
