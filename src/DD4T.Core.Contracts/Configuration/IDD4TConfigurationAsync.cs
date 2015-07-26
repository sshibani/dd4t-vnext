using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Configuration
{
    public interface IDD4TConfigurationAsync
    {
        int PublicationId { get; }
        string DefaultPage { get; }
        string ComponentPresentationController { get; }
        string ComponentPresentationAction { get; }
        string ActiveWebsite { get; }
        string SelectComponentByComponentTemplateId { get; }
        string SelectComponentByOutputFormat { get; }
        string SiteMapPath { get; }
        int BinaryHandlerCacheExpiration { get; }
        string BinaryFileExtensions { get; }
        string BinaryUrlPattern { get; }
        bool IncludeLastPublishedDate { get; }
        bool ShowAnchors { get; }
        bool LinkToAnchor { get; }
        bool UseUriAsAnchor { get; }
        int DefaultCacheSettings { get; }
        int CacheCallBackInterval { get; }
        string DataFormat { get; }
        string ContentProviderEndPoint { get; }
        string ResourcePath { get; }
    }
}
