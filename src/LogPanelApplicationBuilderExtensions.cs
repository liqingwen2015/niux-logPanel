using Microsoft.AspNetCore.Builder;

namespace NiuX.LogPanel
{
    public static class LogPanelApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseLogPanel(this IApplicationBuilder builder, string pathMatch = "/logpanel")
        {
            return builder.Map(pathMatch, app => app.UseMiddleware<LogPanelMiddleware>());
        }
    }
}