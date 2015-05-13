using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Contracts.Resolvers;
using System;

namespace DD4T.Providers.Mock
{
    public class BaseProvider : IProvider
    {
        private readonly IPublicationResolver PublicationResolver;
        public BaseProvider(IPublicationResolver resolver)
        {
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
