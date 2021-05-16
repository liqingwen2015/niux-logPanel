using Microsoft.AspNetCore.Http;
using System;
using NiuX.LogPanel.Routes;

namespace NiuX.LogPanel
{
    public class LogPanelContext
    {

        public HttpContext HttpContext { get; }

        public LogPanelRoute Route { get; }

        public LogPanelOptions Options { get; }


        public static LogPanelOptions? StaticOptions { get; set; }


        public LogPanelContext(HttpContext httpContext, LogPanelRoute route, LogPanelOptions options)
        {
            StaticOptions = options;
            Route = route ?? throw new ArgumentNullException(nameof(route));
            HttpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            Options = options;
        }
    }
}