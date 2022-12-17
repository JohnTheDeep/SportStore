using Microsoft.AspNetCore.Http;

namespace Store.Infrastructure.Extensions
{
    public static class UrlExtension 
    {
        public static string PathAndQuery(this HttpRequest _request) =>
            _request.QueryString.HasValue ? $"{_request.Path}{_request.QueryString}" : _request.Path.ToString();
    }
}
