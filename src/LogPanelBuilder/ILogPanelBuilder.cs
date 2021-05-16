using Microsoft.Extensions.DependencyInjection;

namespace NiuX.LogPanel.LogPanelBuilder
{
    public interface ILogPanelBuilder
    {
        IServiceCollection Services { get; }
    }
}