using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;
using DD4T.ContentModel.Contracts.Providers;
using DD4T.Providers.Mock;
using DD4T.ContentModel.Factories;
using DD4T.Factories;
using DD4T.ContentModel.Contracts.Resolvers;
using DD4T.Utils.Defaults;
using DD4T.Utils;
using Newtonsoft.Json;
using DD4T.ContentModel.Contracts.Configuration;
using DD4T.ContentModel.Contracts.Factories;

namespace DD4T.Bootstrap
{
    public static class IServiceCollectionExtensions
    {

        public static void AddDD4T(this IServiceCollection services)
        {
            var configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            //var config = JsonConvert.DeserializeObject<DD4TConfiguration>()
            //var x = configuration.GetSubKey("DD4TAppSettings");
            
            services.Configure<DD4TConfiguration>(configuration.GetSubKey("DD4TAppSettings"));

            services.AddTransient<IPageProvider, TridionPageProvider>();

            services.AddTransient<IPageFactory, PageFactory>();
            services.AddTransient<IComponentPresentationFactory, ComponentPresentationFactory>();
            services.AddTransient<IComponentPresentationProvider, ComponentPresentationProvider>();
            services.AddSingleton<IPublicationResolver, DefaultPublicationResolver>();
        }
    }
}
