using DD4T.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Factories
{
    public interface ITaxonomyFactoryAsync
    {
        bool TryGetKeyword(string categoryUriToLookIn, string keywordName, out IKeyword keyword);
        IKeyword GetKeyword(string categoryUriToLookIn, string keywordName);
    }
}
