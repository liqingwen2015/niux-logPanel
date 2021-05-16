using System.Threading.Tasks;
using NiuX.LogPanel.Models;
using NiuX.LogPanel.Repositories;

namespace NiuX.LogPanel.Handlers.LogCharts
{
    public interface ILogChart
    {
        Task<GetLogChartsOutput> GetCharts<T>(IRepository<T> repository) where T : class, ILogModel;
    }
}