using System;

namespace NiuX.LogPanel.Routes
{
    /// <summary>
    /// 路由
    /// </summary>
    public class LogPanelRoute
    {
        public LogPanelRoute(string action, Type view)
        {
            Action = action;
            View = view;
        }

        public LogPanelRoute()
        {

        }

        public string Key => $"/{Controller}/{Action}";

        public Type View { get; set; }

        public string Controller { get; set; } = "Home";

        public string Action { get; set; }

        public bool IsHtmlView { get; set; } = true;

    }
}