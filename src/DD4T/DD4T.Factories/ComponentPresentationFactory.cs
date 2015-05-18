using DD4T.ContentModel.Contracts.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DD4T.ContentModel;
using DD4T.ContentModel.Contracts.Providers;
using Microsoft.Framework.Logging;
using Newtonsoft.Json;
using Microsoft.Framework.OptionsModel;
using DD4T.Utils;

namespace DD4T.Factories
{
    public class ComponentPresentationFactory : FactoryBase, IComponentPresentationFactory
    {
        private readonly IComponentPresentationProvider ComponentPresentationProvider;

        public ComponentPresentationFactory(IComponentPresentationProvider componentPresentationProvider, ILoggerFactory loggerfactory, IOptions<DD4TConfiguration> config)
            : base(componentPresentationProvider, loggerfactory, config)
        {
            ComponentPresentationProvider = componentPresentationProvider;
        }

        public Task<IComponentPresentation> GetComponentPresentation(string componentUri, string componentTemplateUri = "")
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetComponentPresentation<T>(string componentUri, string componentTemplateUri = "")
        {
            string cpContentFromBroker = await ComponentPresentationProvider.GetComponentPresentationContent(componentUri, componentTemplateUri);

            if (string.IsNullOrEmpty(cpContentFromBroker))
                return default(T);

            //Create an IPage object from the stringcontent
            return await GetComponentPresentation<T>(cpContentFromBroker);
        }


        public async Task<T> GetComponentPresentation<T>(string cpStringContent)
        {
            var current = Activator.CreateInstance<T>();

            JsonSerializerSettings s = new JsonSerializerSettings { };
            s.Converters.Add(new FieldConverter());
            //page = await JsonConvert.DeserializeObjectAsync<Page>(pageStringContent, s);
            current = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(cpStringContent, s));

            return current;
        }
    }
}
