using DD4T.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Providers
{
    public interface ITaxonomyProviderAsync : IProviderAsync
    {
        IKeyword GetKeyword(string categoryUriToLookIn, string keywordName);
    }
}
