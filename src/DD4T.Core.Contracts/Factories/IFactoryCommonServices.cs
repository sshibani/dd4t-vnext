using DD4T.ContentModel.Contracts.Serializing;
using DD4T.Core.Contracts.Caching;
using DD4T.Core.Contracts.Configuration;
using DD4T.Core.Contracts.Logging;
using DD4T.Core.Contracts.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Factories
{
    public interface IFactoryCommonServices
    {
        IPublicationResolverAsync PublicationResolver { get; }
        ILoggerAsync Logger { get; }
        IDD4TConfigurationAsync Configuration { get; }
        ICacheAgentAsync CacheAgent { get; }
        ISerializerService SerializerService { get; }
    }
}
