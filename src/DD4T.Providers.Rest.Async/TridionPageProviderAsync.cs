using DD4T.ContentModel;
using DD4T.Core.Contracts.Providers;
using System;
using System.Linq;

namespace DD4T.Providers.Rest.Async
{
    public class TridionPageProviderAsync : BaseProviderAsync, IPageProviderAsync
    {
        private const string controller = "api/page";
        public TridionPageProviderAsync(IProviderCommonServices commonServices)
            :base(commonServices)
        {

        }

        public string GetContentByUrl(string url)
        {
            var a = url.Split('.');
            string urlParameters = string.Format("{0}/GetContentByUrl/{1}/{2}/{3}", controller, PublicationId, a.Last(), a.First());
            //returns the content or empty string.
            return Execute<string>(urlParameters);
        }

        public string GetContentByUri(string uri)
        {
            TcmUri tcmUri = new TcmUri(uri);
            string urlParameters = string.Format("{0}/GetContentByUri/{1}/{2}", controller, PublicationId, tcmUri.ItemId);
            return Execute<string>(urlParameters);
        }

        public DateTime GetLastPublishedDateByUrl(string url)
        {
            var a = url.Split('.');
            string urlParameters = string.Format("{0}/GetLastPublishedDateByUrl/{1}/{2}/{3}", controller, PublicationId, a.Last(), a.First());
            //returns the content or empty string.
            return Execute<DateTime>(urlParameters);
        }

        public DateTime GetLastPublishedDateByUri(string uri)
        {
            TcmUri tcmUri = new TcmUri(uri);
            string urlParameters = string.Format("{0}/GetLastPublishedDateByUri/{1}/{2}", controller, PublicationId, tcmUri.ItemId);
            return Execute<DateTime>(urlParameters);
        }

        public string[] GetAllPublishedPageUrls(string[] includeExtensions, string[] pathStarts)
        {
            throw new NotImplementedException();
        }

       
    }
}
