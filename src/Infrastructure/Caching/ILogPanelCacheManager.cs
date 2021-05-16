using System.Collections.Generic;
using System.Threading.Tasks;
using NiuX.LogPanel.Models;

namespace NiuX.LogPanel.Infrastructure.Caching
{
    public interface ILogPanelCacheManager<T> where T : class, ILogModel
    {
        Task Set(string key, List<T> logs);

        Task Clear(string key);

        Task<List<T>> Get(string key);
    }
}