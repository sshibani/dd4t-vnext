using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Providers
{
    public interface IPageProviderAsync : IProviderAsync
    {
        string GetContentByUrl(string url);
        string GetContentByUri(string uri);
        DateTime GetLastPublishedDateByUrl(string url);
        DateTime GetLastPublishedDateByUri(string uri);
        string[] GetAllPublishedPageUrls(string[] includeExtensions, string[] pathStarts);
    }
}
