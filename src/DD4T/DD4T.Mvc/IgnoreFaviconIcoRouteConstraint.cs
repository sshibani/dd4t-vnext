using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DD4T.Mvc
{
    /// <summary>
    /// Custom Route Constraint for ignoring requests to favicon.ico
    /// </summary>
    public class IgnoreFaviconIcoRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection)
        {
            //If the requests contains 'favicon.ico', ignore it            
            if (values.Select(v => v.Value).Where(v => v != null && v.ToString().ToLower().Contains("favicon.ico")).Cast<string>().Count() > 0)
            {
                return false;
            }

            return true;
        }
    }
}