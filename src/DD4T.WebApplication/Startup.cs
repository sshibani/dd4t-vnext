using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using DD4T.Bootstrap;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;

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
            app.UseStaticFiles();
            app.UseDD4T();
            app.UseErrorPage();
        }
    }

    public static class test
    {
        public static void UseMyCustomAuthentication(this IApplicationBuilder builder) { }
        public static void UseDD4TBinary(this IApplicationBuilder builder) { }
    }
}
