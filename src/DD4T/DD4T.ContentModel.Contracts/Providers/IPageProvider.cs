using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD4T.ContentModel.Contracts.Providers
{
    public interface IPageProvider : IProvider
    {
        Task<string> GetContentByUrl(string url);
        //string GetContentByUrl(string url);
        Task<string> GetContentByUri(string uri);
        //string GetContentByUri(string uri);
        Task<DateTime> GetLastPublishedDateByUrl(string url);
        //DateTime GetLastPublishedDateByUrl(string url);
        Task<DateTime> GetLastPublishedDateByUri(string uri);
        //DateTime GetLastPublishedDateByUri(string uri);
        Task<string[]> GetAllPublishedPageUrls(string[] includeExtensions, string[] pathStarts);
        //string[] GetAllPublishedPageUrls(string[] includeExtensions, string[] pathStarts);
    }
}
