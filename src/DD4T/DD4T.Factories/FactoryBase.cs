using DD4T.ContentModel;
using DD4T.ContentModel.Contracts.Providers;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.Logging;

namespace DD4T.Factories
{
    public abstract class FactoryBase
    {
        protected IProvider Provider;
        protected readonly ILogger Logger;
        #region ctor 
        public FactoryBase(IProvider provider, ILoggerFactory loggerfactory)
        {
            Logger = loggerfactory.CreateLogger(typeof(FactoryBase).FullName);
            if (provider == null)
                throw new ArgumentNullException("provider");

            Provider = provider;
        }
        #endregion

        //private ILogger logger = null;
        //public ILogger Logger
        //{
        //    get
        //    {
        //        if (logger == null)
        //            logger = NullLogger.Create();

        //        return logger;
        //    }
        //    set
        //    {
        //        logger = value;
        //    }
        //}

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
                    return Provider.PublicationId;
                return _publicationId.Value;
            }
            set
            {
                _publicationId = value;
            }
        }
        #endregion

        //#region caching
        //private ICacheAgent cacheAgent = null;
        ///// <summary>
        ///// Abstract method to be overridden by each implementation. The method should return the DateTime when the object in the cache was last published.
        ///// </summary>
        ///// <param name="key">Key of the object in the cache</param>
        ///// <param name="cachedItem">The object in the cache</param>
        ///// <returns></returns>
        ////public abstract DateTime GetLastPublishedDateCallBack(string key, object cachedItem);

        ///// <summary>
        ///// Get or set the CacheAgent
        ///// </summary>  
        //public virtual ICacheAgent CacheAgent
        //{
        //    get
        //    {
        //        if (cacheAgent == null)
        //        {
        //            // null 
        //            //_cacheAgent = new DefaultCacheAgent();
        //            cacheAgent = null;
        //        }
        //        return cacheAgent;
        //    }
        //    set
        //    {
        //        cacheAgent = value;
        //    }
        //}

        //#endregion

        #region private properties
        protected bool IncludeLastPublishedDate
        {
            get
            {
                //Todo: Fix Me
                //return Configuration.IncludeLastPublishedDate;
                return true;
            }
        }
        #endregion


        /// <summary>
        /// Used in deserializing of a Component. 
        /// </summary>
        public class FieldConverter : CustomCreationConverter<IField>
        {
            public override IField Create(Type objectType)
            {
                return new Field();
            }
        }
    }
}
