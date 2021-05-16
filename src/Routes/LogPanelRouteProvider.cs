using NiuX.LogPanel.Views.Home;

namespace NiuX.LogPanel.Routes
{
    /// <summary>
    /// 路线提供者
    /// </summary>
    public static class LogPanelRouteProvider
    {
        public static RouteCollection Routes { get; }

        static LogPanelRouteProvider()
        {
            Routes = new();
            Routes.AddRoute(new LogPanelRoute(nameof(Index), typeof(Index)));

            Routes.AddRoute(new LogPanelRoute("SearchLog", typeof(LogList)));

            Routes.AddRoute(new LogPanelRoute(nameof(Basic), typeof(Basic)));

            Routes.AddRoute(new LogPanelRoute("ErrorLog", typeof(LogList)));

            Routes.AddRoute(new LogPanelRoute("Detail", typeof(Detail)));

            Routes.AddRoute(new LogPanelRoute
            {
                Action = "GetException",
                IsHtmlView = false
            });

            Routes.AddRoute(new LogPanelRoute
            {
                Action = "RequestTrace",
                IsHtmlView = false
            });

            Routes.AddRoute(new LogPanelRoute
            {
                Action = "GetLogChart",
                IsHtmlView = false
            });

        }
    }
}