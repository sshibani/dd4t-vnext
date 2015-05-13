using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.ContentModel.Contracts.Providers
{
    public interface IComponentPresentationProvider : IProvider
    {
        Task<string> GetComponentPresentationContent(string componentUri, string componentTemplateUri = "");
    }
}
