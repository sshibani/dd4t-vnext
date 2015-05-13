using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Contracts.Resolvers;
using System;
using System.Threading.Tasks;

namespace DD4T.Providers.Mock
{
    public class TridionPageProvider : BaseProvider, IPageProvider
    {

        public TridionPageProvider(IPublicationResolver publicationResolver)
            : base (publicationResolver )
        {

        }

        public async Task<string> GetContentByUrl(string url)
        {
            //return await new Task<string>(() => { return "{\"revisionDate\":\"2014-09-26T21:30:18.273\",\"filename\":\"a\",\"lastPublishedDate\":\"0001-01-01T00:00:00\",\"pageTemplate\":{\"fileExtension\":\"mvc\",\"revisionDate\":\"2014-01-22T20:26:03.503\",\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-2018-2\",\"title\":\"JSON\"},\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-3149-128\",\"title\":\"Index\"},\"schema\":{\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-5020-2\",\"title\":\"Metadata\"},\"rootElementName\":\"undefined\",\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-12162-8\",\"title\":\"Page metadata\"},\"metadataFields\":{\"stringrange\":{\"name\":\"stringrange\",\"value\":\"aa\",\"values\":[\"aa\"],\"numericValues\":[],\"dateTimeValues\":[],\"linkedComponentValues\":[],\"fieldType\":0,\"xPath\":\"Metadata/custom:stringrange\",\"keywords\":[]}},\"componentPresentations\":[{\"component\":{\"lastPublishedDate\":\"0001-01-01T00:00:00\",\"revisionDate\":\"2014-03-12T06:51:14.803\",\"schema\":{\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-13-2\",\"title\":\"Schemas\"},\"rootElementName\":\"Content\",\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-123-8\",\"title\":\"Article\"},\"fields\":{},\"metadataFields\":{},\"componentType\":1,\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-15-2\",\"title\":\"Content\"},\"categories\":[{\"keywords\":[],\"id\":\"tcm:9-4021-512\",\"title\":\"Product Group\"}],\"version\":4,\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"owningPublication\":{\"id\":\"tcm:0-5-1\",\"title\":\"04 Dutch Content\"},\"id\":\"tcm:9-3152\",\"title\":\"Homepage teaser 2\"},\"componentTemplate\":{\"outputFormat\":\"HTML Fragment\",\"revisionDate\":\"2014-08-29T15:42:14.953\",\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-14-2\",\"title\":\"Component Templates\"},\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-3148-32\",\"title\":\"Article\"},\"isDynamic\":true,\"orderOnPage\":0}],\"structureGroup\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-2019-4\",\"title\":\"Products\"},\"categories\":[{\"keywords\":[],\"id\":\"tcm:9-4021-512\",\"title\":\"Product Group\"}],\"version\":2,\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"owningPublication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-4151-64\",\"title\":\"Product - A\"}"; });
            var task = new Task<string>(() => { return "{\"revisionDate\":\"2014-09-26T21:30:18.273\",\"filename\":\"a\",\"lastPublishedDate\":\"0001-01-01T00:00:00\",\"pageTemplate\":{\"fileExtension\":\"mvc\",\"revisionDate\":\"2014-01-22T20:26:03.503\",\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-2018-2\",\"title\":\"JSON\"},\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-3149-128\",\"title\":\"Index\"},\"schema\":{\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-5020-2\",\"title\":\"Metadata\"},\"rootElementName\":\"undefined\",\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-12162-8\",\"title\":\"Page metadata\"},\"metadataFields\":{\"stringrange\":{\"name\":\"stringrange\",\"value\":\"aa\",\"values\":[\"aa\"],\"numericValues\":[],\"dateTimeValues\":[],\"linkedComponentValues\":[],\"fieldType\":0,\"xPath\":\"Metadata/custom:stringrange\",\"keywords\":[]}},\"componentPresentations\":[{\"component\":{\"lastPublishedDate\":\"0001-01-01T00:00:00\",\"revisionDate\":\"2014-03-12T06:51:14.803\",\"schema\":{\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-13-2\",\"title\":\"Schemas\"},\"rootElementName\":\"Content\",\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-123-8\",\"title\":\"Article\"},\"fields\":{},\"metadataFields\":{},\"componentType\":1,\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-15-2\",\"title\":\"Content\"},\"categories\":[{\"keywords\":[],\"id\":\"tcm:9-4021-512\",\"title\":\"Product Group\"}],\"version\":4,\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"owningPublication\":{\"id\":\"tcm:0-5-1\",\"title\":\"04 Dutch Content\"},\"id\":\"tcm:9-3152\",\"title\":\"Homepage teaser 2\"},\"componentTemplate\":{\"outputFormat\":\"HTML Fragment\",\"revisionDate\":\"2014-08-29T15:42:14.953\",\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-14-2\",\"title\":\"Component Templates\"},\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-3148-32\",\"title\":\"Article\"},\"isDynamic\":true,\"orderOnPage\":0}],\"structureGroup\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-2019-4\",\"title\":\"Products\"},\"categories\":[{\"keywords\":[],\"id\":\"tcm:9-4021-512\",\"title\":\"Product Group\"}],\"version\":2,\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"owningPublication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-4151-64\",\"title\":\"Product - A\"}"; });
            task.Start();
            return await task;
        }


        public Task<string[]> GetAllPublishedPageUrls(string[] includeExtensions, string[] pathStarts)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetContentByUri(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime> GetLastPublishedDateByUri(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime> GetLastPublishedDateByUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
