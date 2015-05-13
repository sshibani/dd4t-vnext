using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Contracts.Resolvers;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Providers.Mock
{
    public class ComponentPresentationProvider : BaseProvider, IComponentPresentationProvider
    {
        public ComponentPresentationProvider(IPublicationResolver publicationResolver, ILoggerFactory loggerfactory)
            : base(publicationResolver, loggerfactory)
        {

        }
        public async Task<string> GetComponentPresentationContent(string componentUri, string componentTemplateUri = "")
        {
            var task = new Task<string>(() => { return "{\"component\":{\"lastPublishedDate\":\"0001-01-01T00:00:00\",\"revisionDate\":\"2014-03-12T06:51:14.803\",\"schema\":{\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-13-2\",\"title\":\"Schemas\"},\"rootElementName\":\"Content\",\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-123-8\",\"title\":\"Article\"},\"fields\":{},\"metadataFields\":{},\"componentType\":1,\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-15-2\",\"title\":\"Content\"},\"categories\":[{\"keywords\":[],\"id\":\"tcm:9-4021-512\",\"title\":\"Product Group\"}],\"version\":4,\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"owningPublication\":{\"id\":\"tcm:0-5-1\",\"title\":\"04 Dutch Content\"},\"id\":\"tcm:9-3152\",\"title\":\"Homepage teaser 2\"},\"componentTemplate\":{\"outputFormat\":\"HTML Fragment\",\"revisionDate\":\"2014-08-29T15:42:14.953\",\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-14-2\",\"title\":\"Component Templates\"},\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-3148-32\",\"title\":\"Article\"},\"isDynamic\":true,\"orderOnPage\":0}"; });
            task.Start();
            return await task;
        }
    }
}
