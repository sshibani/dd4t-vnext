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
        public DD4TConfiguration Config { get; private set; }
        public DefaultPublicationResolver(IOptions<DD4TConfiguration> config)
        {
            Config = null;
        }

        public int ResolvePublicationId()
        {
            return 3;
        }
    }
}
