using System;
using DD4T.ContentModel.Contracts.Caching;
using DD4T.Utils;
using DD4T.ContentModel.Contracts.Resolvers;
using DD4T.ContentModel.Contracts.Serializing;
using DD4T.ContentModel;
using DD4T.Serialization;
using DD4T.ContentModel.Contracts.Configuration;
using DD4T.ContentModel.Contracts.Logging;
using DD4T.ContentModel.Factories;

namespace DD4T.Factories
{
    /// <summary>
    /// Base class for all factories
    /// </summary>
    public abstract class FactoryBase
    {

        public IPublicationResolver PublicationResolver { get; set; }
        public ICacheAgent CacheAgent { get; set; }

        protected readonly IDD4TConfiguration Configuration;
        protected readonly ILogger LoggerService;
        protected readonly ISerializerService SerializerService;

        public FactoryBase(IFactoriesFacade facade)
        {
            if (facade == null)
                throw new ArgumentNullException("facade");

            LoggerService = facade.Logger;
            PublicationResolver = facade.PublicationResolver;
            Configuration = facade.Configuration;
            CacheAgent = facade.CacheAgent;
            SerializerService = facade.SerializerService;
            CacheAgent.GetLastPublishDateCallBack = GetLastPublishedDateCallBack;
           
        }

        /// <summary>
        /// Abstract method to be overridden by each implementation. The method should return the DateTime when the object in the cache was last published.
        /// </summary>
        /// <param name="key">Key of the object in the cache</param>
        /// <param name="cachedItem">The object in the cache</param>
        /// <returns></returns>
        public abstract DateTime GetLastPublishedDateCallBack(string key, object cachedItem);


        #region publication resolving
        private int? _publicationId = null;

        /// <summary>
        /// Returns the current publicationId
        /// </summary>  
        protected virtual int PublicationId 
        {
            get
            {
                if (_publicationId == null)
                    return PublicationResolver.ResolvePublicationId();
                return _publicationId.Value;
            }
            set
            {
                _publicationId = value;
            }
        }
        #endregion

        #region private properties
        protected bool IncludeLastPublishedDate
        {
            get
            {
                return Configuration.IncludeLastPublishedDate;
            }
        }
        #endregion

       
    }
}
