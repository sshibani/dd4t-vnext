using DD4T.ContentModel.Contracts.Caching;
using DD4T.ContentModel.Contracts.Configuration;
using DD4T.ContentModel.Contracts.Logging;
using DD4T.ContentModel.Contracts.Resolvers;
using DD4T.ContentModel.Contracts.Serializing;

namespace DD4T.ContentModel.Factories
{
    public interface IFactoriesFacade
    {
        IPublicationResolver PublicationResolver { get; }
        ILogger Logger { get; }
        IDD4TConfiguration Configuration { get; }
        ICacheAgent CacheAgent { get; }
        ISerializerService SerializerService { get; }

    }
}
