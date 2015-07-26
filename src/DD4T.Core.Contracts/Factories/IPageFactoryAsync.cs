using DD4T.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Factories
{
    public interface IPageFactoryAsync
    {
        bool TryFindPage(string url, out IPage page);
        IPage FindPage(string url);
        bool TryGetPage(string tcmUri, out IPage page);
        IPage GetPage(string tcmUri);
        bool TryFindPageContent(string url, out string pageContent);
        string FindPageContent(string url);
        bool TryGetPageContent(string tcmUri, out string pageContent);
        string GetPageContent(string tcmUri);
        bool HasPageChanged(string url);
        DateTime GetLastPublishedDateByUrl(string url);
        DateTime GetLastPublishedDateByUri(string uri);
        string[] GetAllPublishedPageUrls(string[] includeExtensions, string[] pathStarts);
        IPage GetIPageObject(string pageStringContent);
    }
}
