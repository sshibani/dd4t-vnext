using DD4T.ContentModel.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DD4T.ContentModel;
using DD4T.ContentModel.Contracts.Providers;
using Newtonsoft.Json;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using DD4T.Utils;

namespace DD4T.Factories
{
    public class PageFactory : FactoryBase, IPageFactory
    {
        private readonly IPageProvider PageProvider;
       // private readonly INewComponentPresentationProvider ComponentPresentationProvider;

        public PageFactory(IPageProvider pageProvider, ILoggerFactory loggerfactory, IOptions<DD4TConfiguration> config)
            : base(pageProvider, loggerfactory, config)
        {
            PageProvider = pageProvider;
        }

        public async Task<IPage> GetPage(string pageUrl)
        {
            string pageContentFromBroker = await PageProvider.GetContentByUrl(pageUrl);

            if (string.IsNullOrEmpty(pageContentFromBroker))
                return null;

            //Create an IPage object from the stringcontent
            return await GetIPageObject(pageContentFromBroker);
        }

        public async Task<T> GetPage<T>(string pageUrl)
        {
            string pageContentFromBroker = await PageProvider.GetContentByUrl(pageUrl);

            if (string.IsNullOrEmpty(pageContentFromBroker))
                return default(T);

            //Create an IPage object from the stringcontent
            return await GetIPageObject<T>(pageContentFromBroker);
        }



        public async Task<T> GetIPageObject<T>(string pageStringContent)
        {
            // IPage page;
            var current = Activator.CreateInstance<T>();

            JsonSerializerSettings s = new JsonSerializerSettings { };
            s.Converters.Add(new FieldConverter());
            //page = await JsonConvert.DeserializeObjectAsync<Page>(pageStringContent, s);
            current = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(pageStringContent, s));

            return current;
        }

        #region Private Helpers
        public async Task<IPage> GetIPageObject(string pageStringContent)
        {
            IPage page;

            //Logger.LogDebug("GetIPageObject: about to deserialize and decompress", LoggingCategory.Performance);
            JsonSerializerSettings s = new JsonSerializerSettings { };
            s.Converters.Add(new FieldConverter());
            //page = await JsonConvert.DeserializeObjectAsync<Page>(pageStringContent, s);
            page = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Page>(pageStringContent, s));

            //page = ProtoBuf.Serializer.Deserialize<Page>(new MemoryStream(Convert.FromBase64String(pageStringContent)));
            //var t = ProtoBuf.Serializer.Deserialize<TempModel>(new MemoryStream(Convert.FromBase64String(pageStringContent)));

            //Logger.LogDebug("GetIPageObject: finished deserializing and decompressing", LoggingCategory.Performance);
            int orderOnPage = 0;
            foreach (IComponentPresentation cp in page.ComponentPresentations)
            {
                cp.OrderOnPage = orderOnPage++;
            }
            //Logger.LogDebug("GetIPageObject: about to load DCPs", LoggingCategory.Performance);
            //LoadComponentModelsFromComponentFactory(page);
            //Logger.LogDebug("GetIPageObject: finished loading DCPs", LoggingCategory.Performance);

            //Logger.LogDebug("<<GetIPageObject(string length {0})", LoggingCategory.Performance, Convert.ToString(pageStringContent.Length));
            return page;
        }
        #endregion

    }
}
