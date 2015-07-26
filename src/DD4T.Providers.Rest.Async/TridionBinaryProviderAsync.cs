using DD4T.ContentModel;
using DD4T.Core.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD4T.Providers.Rest.Async
{
    public class TridionBinaryProviderAsync : BaseProviderAsync, IBinaryProviderAsync
    {
        private const string controller = "api/binary";
        public TridionBinaryProviderAsync(IProviderCommonServices commonServices)
            :base(commonServices)
        {

        }

        public byte[] GetBinaryByUri(string uri)
        {
            TcmUri tcmUri = new TcmUri(uri);
            string urlParameters = string.Format("{0}/GetContentByUri/{1}/{2}", controller, PublicationId, tcmUri.ItemId);
            return Execute<byte[]>(urlParameters);
        }

        public byte[] GetBinaryByUrl(string url)
        {
            var a = url.Split('.');
            string urlParameters = string.Format("{0}/GetBinaryByUrl/{1}/{2}/{3}", controller, PublicationId, a.Last(), a.First());
            //returns the content or empty string.
            return Execute<byte[]>(urlParameters);
        }

        public Stream GetBinaryStreamByUri(string uri)
        {
            TcmUri tcmUri = new TcmUri(uri);
            string urlParameters = string.Format("{0}/GetBinaryStreamByUri/{1}/{2}", controller, PublicationId, tcmUri.ItemId);
            return Execute<Stream>(urlParameters);
        }

        public Stream GetBinaryStreamByUrl(string url)
        {
            var a = url.Split('.');
            string urlParameters = string.Format("{0}/GetBinaryStreamByUrl/{1}/{2}/{3}", controller, PublicationId, a.Last(), a.First());
            //returns the content or empty string.
            return Execute<Stream>(urlParameters);
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

        public string GetUrlForUri(string uri)
        {
            TcmUri tcmUri = new TcmUri(uri);
            string urlParameters = string.Format("{0}/GetUrlForUri/{1}/{2}", controller, PublicationId, tcmUri.ItemId);
            return Execute<string>(urlParameters);
        }
    }
}
