﻿using System;
using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Contracts.Caching;
using DD4T.ContentModel.Contracts.Resolvers;
using System.Threading.Tasks;

namespace DD4T.ContentModel.Factories
{
    public interface IPageFactory
    {
        Task<IPage> GetPage(string pageUrl);
        Task<T> GetPage<T>(string pageUrl);
        //bool TryFindPage(string url, out IPage page);
        //Task<IPage> FindPage(string url);
        //      IPageProvider PageProvider { get; set; }
        //      ICacheAgent CacheAgent { get; set; }
        //      IPublicationResolver PublicationResolver { get; set; }
        //      bool TryFindPage(string url, out IPage page);
        //      IPage FindPage(string url);
        //      bool TryGetPage(string tcmUri, out IPage page);
        //      IPage GetPage(string tcmUri);
        //      bool TryFindPageContent(string url, out string pageContent);
        //      string FindPageContent(string url);
        //      bool TryGetPageContent(string tcmUri, out string pageContent);
        //      string GetPageContent(string tcmUri);
        //      bool HasPageChanged(string url);
        //      DateTime GetLastPublishedDateByUrl(string url);
        //DateTime GetLastPublishedDateByUri(string uri);
        //      string[] GetAllPublishedPageUrls(string[] includeExtensions, string[] pathStarts);
        //      IPage GetIPageObject(string pageStringContent);
    }
}
