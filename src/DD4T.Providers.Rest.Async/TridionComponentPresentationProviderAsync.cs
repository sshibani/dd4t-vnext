using DD4T.ContentModel;
using DD4T.Core.Contracts.Providers;
using System;
using System.Collections.Generic;

namespace DD4T.Providers.Rest.Async
{
    public class TridionComponentPresentationProviderAsync : BaseProviderAsync, IComponentPresentationProviderAsync
    {
        private const string controller = "api/componentpresentation";
        public TridionComponentPresentationProviderAsync(IProviderCommonServices commonServices)
            : base(commonServices)
        {

        }
        public string GetContent(string uri, string templateUri = "")
        {

            string urlParameters = string.IsNullOrEmpty(templateUri) ?
                string.Format("{0}/GetContent/{1}/{2}", controller, PublicationId, new TcmUri(uri).ItemId) :
                string.Format("{0}/GetContent/{1}/{2}/{3}", controller, PublicationId, new TcmUri(uri).ItemId, new TcmUri(templateUri).ItemId);

            return Execute<string>(urlParameters);
        }

        public DateTime GetLastPublishedDate(string uri)
        {
            TcmUri componentUri = new TcmUri(uri);
            string urlParameters = string.Format("{0}/GetLastPublishedDate/{1}/{2}", controller, PublicationId, componentUri.ItemId);
            return Execute<DateTime>(urlParameters);
        }

        public List<string> GetContentMultiple(string[] componentUris)
        {
            throw new NotImplementedException();
        }

        public IList<string> FindComponents(ContentModel.Querying.IQuery queryParameters)
        {
            throw new NotImplementedException();
        }
    }
}
