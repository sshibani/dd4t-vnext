using System;
using System.Collections.Generic;

namespace DD4T.Core.Contracts.Providers
{
    public interface IComponentPresentationProviderAsync : IProviderAsync
    {
        string GetContent(string uri, string templateUri = "");
        DateTime GetLastPublishedDate(string uri);
        List<string> GetContentMultiple(string[] componentUris);
      
    }
}
