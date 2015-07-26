using DD4T.ContentModel;
using DD4T.Core.Contracts.Providers;

namespace DD4T.Providers.Rest.Async
{
    public class TridionLinkProviderAsync : BaseProviderAsync, ILinkProviderAsync
    {
        private const string controller = "api/link";
        public TridionLinkProviderAsync(IProviderCommonServices commonServices)
            :base(commonServices)
        {

        }
        public string ResolveLink(string componentUri)
        {
            TcmUri tcmUri = new TcmUri(componentUri);
            string urlParameters = string.Format("{0}/ResolveLink/{1}/{2}", controller, PublicationId, tcmUri.ItemId);
            return Execute<string>(urlParameters);
        }

        public string ResolveLink(string sourcePageUri, string componentUri, string excludeComponentTemplateUri)
        {
            
            var compUri = new TcmUri(componentUri);
            var pageUri = new TcmUri(sourcePageUri);
            var templateUri = new TcmUri(excludeComponentTemplateUri);

            string urlParameters = string.Format("{0}/ResolveLink/{1}/{2}/{3}/{4}", controller, PublicationId, pageUri.ItemId, compUri.ItemId, templateUri.ItemId);
            return Execute<string>(urlParameters);
        }
    }
}
