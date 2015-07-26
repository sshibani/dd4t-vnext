using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DD4T.ContentModel.Contracts.Resolvers
{
    [Obsolete("user the Async version of the interface in DD4T.Core.Contracts")]
    public interface IPublicationResolver
    {
        int ResolvePublicationId();
    }
}
