using DD4T.ContentModel.Contracts.Resolvers;
using Microsoft.Framework.OptionsModel;


namespace DD4T.Utils.Defaults
{
    public class DefaultPublicationResolver : IPublicationResolver
    {
        private readonly DD4TConfiguration Configuration;

        public DefaultPublicationResolver(IOptions<DD4TConfiguration> config)
        {
            Configuration = config.Options;
        }

        public int ResolvePublicationId()
        {
            return Configuration.PublicationId;
        }
    }
}
