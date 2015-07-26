using DD4T.ContentModel;
using DD4T.Core.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Core.Contracts.Factories
{
    public interface IComponentPresentationFactoryAsync
    {
        IComponentPresentation GetComponentPresentation(string componentUri, string templateUri = "");
        bool TryGetComponentPresentation(out IComponentPresentation cp, string componentUri, string templateUri = "");
        IComponentPresentation GetIComponentPresentationObject(string componentPresentationStringContent);
        DateTime GetLastPublishedDate(string componentUri, string templateUri = "");
        IList<IComponentPresentation> GetComponentPresentations(string[] componentUris); // TODO: think of a way to pass a list of 'component + template uris' (maybe Tuples?)
        //IList<IComponentPresentation> FindComponentPresentations(IQuery queryParameters);
        //IList<IComponentPresentation> FindComponentPresentations(IQuery queryParameters, int pageIndex, int pageSize, out int totalCount);
    }
}
