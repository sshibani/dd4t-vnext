using DD4T.ContentModel.Contracts.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
