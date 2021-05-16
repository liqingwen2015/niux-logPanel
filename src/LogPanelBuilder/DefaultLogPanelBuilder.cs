using Microsoft.Extensions.DependencyInjection;

namespace NiuX.LogPanel.LogPanelBuilder
{
    public class DefaultLogPanelBuilder : ILogPanelBuilder
    {
        public DefaultLogPanelBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}