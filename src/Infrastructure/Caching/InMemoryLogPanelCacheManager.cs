using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NiuX.LogPanel.Models;

namespace NiuX.LogPanel.Infrastructure.Caching
{
    public class InMemoryLogPanelCacheManager<T> : ILogPanelCacheManager<T> where T : class, ILogModel
    {
        private readonly ConcurrentDictionary<string, List<T>> _caches = new ConcurrentDictionary<string, List<T>>();

        private Timer? _timer;

        private readonly LogPanelOptions _options;

        public InMemoryLogPanelCacheManager(LogPanelOptions options) => _options = options;

        public Task Set(string key, List<T> logs)
        {
            _timer ??= new Timer(async _ => await Clear(LogPanelConsts.CacheKey).ConfigureAwait(false), null, _options.CacheExpires, _options.CacheExpires);
            _caches.AddOrUpdate(key, logs, (_, _) => logs);
            return Task.CompletedTask;

        }

        public Task Clear(string key)
        {
            _caches.TryRemove(key, out _);
            _timer?.Dispose();
            _timer = null;
            return Task.CompletedTask;
        }


        public Task<List<T>> Get(string key) => _caches.GetOrAdd(key, _ => new List<T>()).ToTaskResult();
    }

}