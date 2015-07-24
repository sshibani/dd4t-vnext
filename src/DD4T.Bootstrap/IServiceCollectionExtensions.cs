using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;
using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Factories;
using DD4T.Factories;
using DD4T.ContentModel.Contracts.Resolvers;
using DD4T.Utils.Resolver;
using DD4T.ContentModel.Contracts.Logging;
using DD4T.Utils.Logging;
using DD4T.ContentModel.Contracts.Caching;
using DD4T.Utils.Caching;
using DD4T.Providers.Mock;
using DD4T.ContentModel.Contracts.Configuration;
using DD4T.Utils;

namespace DD4T.Bootstrap
{
    public static class IServiceCollectionExtensions
    {

        public static void AddDD4T(this IServiceCollection services)
        {
           //var configuration = new Configuration()
           //     .AddJsonFile("config.json")
           //     .AddEnvironmentVariables();

            //var config = JsonConvert.DeserializeObject<DD4TConfiguration>()
            //var x = configuration.GetSubKey("DD4TAppSettings");

            services.AddSingleton<IPublicationResolver, DefaultPublicationResolver>();
            services.AddSingleton<ILogger, NullLogger>();
            services.AddSingleton<ICacheAgent, NullCacheAgent>();
            services.AddSingleton<IDD4TConfiguration, DD4TConfiguration>();
            //services.Configure<DD4TConfiguration>(configuration.GetSubKey("DD4TAppSettings"));

            services.AddTransient<IPageProvider, TridionPageProvider>();
            services.AddTransient<IComponentPresentationProvider, ComponentPresentationProvider>();
            services.AddTransient<ILinkProvider, LinkProvider>();



            services.AddTransient<IFactoriesFacade, FactoriesFacade>();
            services.AddTransient<IPageFactory, PageFactory>();
            services.AddTransient<IComponentFactory, ComponentFactory>();
            services.AddTransient<IComponentPresentationFactory, ComponentPresentationFactory>();
            services.AddTransient<IBinaryFactory, BinaryFactory>();
            services.AddTransient<ILinkFactory, LinkFactory>();

        
        }
    }
}
