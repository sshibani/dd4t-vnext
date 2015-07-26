using DD4T.ContentModel;
using DD4T.Core.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Factories
{
    public interface IBinaryFactoryAsync
    {
        bool TryFindBinary(string url, out IBinary binary);
        IBinary FindBinary(string url);
        bool TryGetBinary(string tcmUri, out IBinary binary);
        IBinary GetBinary(string tcmUri);
        bool TryFindBinaryContent(string url, out byte[] bytes);
        byte[] FindBinaryContent(string url);
        bool TryGetBinaryContent(string tcmUri, out byte[] bytes);
        byte[] GetBinaryContent(string tcmUri);
        bool HasBinaryChanged(string url);
        DateTime FindLastPublishedDate(string url);
        bool LoadBinariesAsStream { get; set; }
        string GetUrlForUri(string uri);
    }
}
