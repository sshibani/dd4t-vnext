using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using DD4T.Bootstrap;

namespace DD4T.WebApplication
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddMvc();
            services.AddDD4T();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseDD4T();

            //app.UseMvc(r => r.MapRoute(
            //        name: "TridionPage",
            //        template: "{*PageUrl}",
            //        defaults: new { controller = "Page", action = "PageAsyncFor" }
            //        )
            //);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
