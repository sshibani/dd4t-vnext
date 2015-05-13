using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using DD4T.Mvc.DefaultBootstrap;
using Microsoft.AspNet.Hosting;
using DD4T.Utils;


namespace DD4T.WebApplication
{
    public class Startup
    {
        //public IConfiguration Configuration { get; set; }

        //public Startup(IHostingEnvironment env)
        //{
        //    // Setup configuration sources.
        //    var configuration = new Configuration()
        //        .AddJsonFile("dd4t-config.json");

        //    configuration.AddEnvironmentVariables();
        //    Configuration = configuration;
        //}


        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(Microsoft.Framework.DependencyInjection.IServiceCollection services)
        {
            
            //services.Configure<DD4TConfiguration>(Configuration.GetSubKey("DD4TAppSettings"));
            services.AddMvc();
            services.AddDD4T();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseDD4T();
           
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
