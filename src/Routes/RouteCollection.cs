using System;
using System.Collections.Generic;
using System.Linq;

namespace NiuX.LogPanel.Routes
{
    public class RouteCollection
    {
        private static readonly List<LogPanelRoute> Routes = new();

        public void AddRoute(LogPanelRoute route)
        {
            if (route == null)
            {
                throw new ArgumentNullException(nameof(route));
            }

            if (string.IsNullOrWhiteSpace(route.Key))
            {
                throw new ArgumentNullException("route key can not be null");
            }

            if (route.IsHtmlView && route.View == null)
            {
                throw new ArgumentNullException("route view can not be null");
            }


            if (string.IsNullOrWhiteSpace(route.Controller) || string.IsNullOrWhiteSpace(route.Action))
            {
                try
                {
                    var routeArray = route.Key.Split('/');
                    route.Controller = routeArray[1];
                    route.Action = routeArray[2];
                }
                catch (Exception ex)
                {
                    if (route.IsHtmlView)
                    {
                        throw new ArgumentException("route key fotmat handle/action", ex);
                    }

                }


            }

            if (Routes.Exists(x => x.Key == route.Key))
            {
                Routes[Routes.IndexOf(Routes.FirstOrDefault(x => x.Key == route.Key))] = route;
            }
            else
            {
                Routes.Add(route);
            }

        }

        public LogPanelRoute? FindRoute(string url)
        {
            return url.IsNullOrWhiteSpace() ? Routes.First(x => x.Controller.IsEqual("Home") && x.Action.IsEqual("Index")) : Routes.FirstOrDefault(x => x.Key.IsEqual(url));
        }

    }

}