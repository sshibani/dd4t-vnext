using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Factories
{
    public interface ILinkFactoryAsync
    {
        string ResolveLink(string componentUri);
        string ResolveLink(string sourcePageUri, string componentUri, string excludeComponentTemplateUri);
    }
}
