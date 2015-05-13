using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.ContentModel.Contracts.Factories
{
    public interface IComponentPresentationFactory
    {
        Task<IComponentPresentation> GetComponentPresentation(string componentUri, string componentTemplateUri = "");

        Task<T> GetComponentPresentation<T>(string componentUri, string componentTemplateUri = "");
    }
}
