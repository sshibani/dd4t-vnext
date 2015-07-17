using DD4T.ContentModel.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Providers.Mock
{
    public class LinkProvider : ILinkProvider
    {
        public int PublicationId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string ResolveLink(string componentUri)
        {
            throw new NotImplementedException();
        }

        public string ResolveLink(string sourcePageUri, string componentUri, string excludeComponentTemplateUri)
        {
            throw new NotImplementedException();
        }
    }
}
