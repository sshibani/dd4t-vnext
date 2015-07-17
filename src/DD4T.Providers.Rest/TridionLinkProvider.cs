using DD4T.ContentModel;
using DD4T.ContentModel.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD4T.Providers.Rest
{
    public class TridionLinkProvider : BaseProvider, ILinkProvider
    {
        private const string controller = "api/link";
        public TridionLinkProvider(IProvidersFacade facade)
            :base(facade)
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
