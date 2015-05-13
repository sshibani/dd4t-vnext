using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Contracts.Resolvers;
using System;
using Microsoft.Framework.Logging;

namespace DD4T.Providers.Mock
{
    public class BaseProvider : IProvider
    {
        private readonly IPublicationResolver PublicationResolver;
        protected readonly ILogger Logger;

        public BaseProvider(IPublicationResolver resolver, ILoggerFactory loggerfactory)
        {
            Logger = loggerfactory.CreateLogger(typeof(BaseProvider).FullName);
            if (resolver == null)
                throw new ArgumentNullException("resolver");

            PublicationResolver = resolver;

        }
        private int publicationId = 0;
        public int PublicationId
        {
            get
            {
                if (publicationId == 0)
                    return PublicationResolver.ResolvePublicationId();

                return publicationId;
            }
            set
            {
                publicationId = value;
            }
        }
    }
}
