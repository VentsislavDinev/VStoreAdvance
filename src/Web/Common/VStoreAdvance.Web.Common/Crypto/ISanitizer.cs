using Abp.Application.Services;

namespace VStoreAdvance.Web.Common.Crypto
{
    public interface ISanitizer : IApplicationService
    {
        string Sanitize(string html);
    }
}