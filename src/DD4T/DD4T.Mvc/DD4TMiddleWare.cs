using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using System;
using System.Threading.Tasks;

namespace DD4T.Mvc
{
    public class DD4TMiddleWare
    {

        private readonly IRouter _router;
        private readonly RequestDelegate _next;
        public DD4TMiddleWare(RequestDelegate next, IRouter router)
        {
            _next = next;
            _router = router;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var rcontext = new RouteContext(httpContext);
            rcontext.RouteData.Routers.Add(_router);

            await _router.RouteAsync(rcontext);

            if (!rcontext.IsHandled)
            {
                await _next.Invoke(httpContext);
            }
        }
    }
}