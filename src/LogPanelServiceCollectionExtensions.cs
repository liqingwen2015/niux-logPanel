using System;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NiuX.LogPanel.Controllers;
using NiuX.LogPanel.Handlers;
using NiuX.LogPanel.Infrastructure.Caching;
using NiuX.LogPanel.LogPanelBuilder;
using NiuX.LogPanel.Repositories;
using NiuX.LogPanel.Repositories.Dapper;
using NiuX.LogPanel.Repositories.Files;
using NiuX.LogPanel.Routes;
using NiuX.LogPanel.Views;

namespace NiuX.LogPanel
{
    public static class LogPanelServiceCollectionExtensions
    {


        public static ILogPanelBuilder AddLogPanel(this IServiceCollection services, Action<LogPanelOptions> func = null)
        {
            var builder = new DefaultLogPanelBuilder(services);

            RegisterServices(services, func);

            return builder;
        }


        private static void RegisterServices(IServiceCollection services, Action<LogPanelOptions> func = null, Assembly currentAssembly = null)
        {


            services.AddSingleton(typeof(ILogPanelCacheManager<>), typeof(InMemoryLogPanelCacheManager<>));

            // options
            var options = new LogPanelOptions();
            func?.Invoke(options);

            services.AddSingleton(options);

            if (options.DatabaseSource)
            {
                DapperExtensions.DapperAsyncExtensions.DefaultMapper = typeof(LogModelMapper<>);
                DapperExtensions.DapperExtensions.DefaultMapper = typeof(LogModelMapper<>);
                DapperExtensions.DapperAsyncExtensions.SqlDialect = options.SqlDialect;
                DapperExtensions.DapperExtensions.SqlDialect = options.SqlDialect;

                if (options.DbConnectionFactory == null)
                {
                    throw new ArgumentNullException(nameof(options.DbConnectionFactory));
                }

                services.AddTransient(typeof(DbConnection), provider => options.DbConnectionFactory.Invoke());

                services.AddTransient(typeof(IRepository<>), typeof(DapperRepository<>));

                services.AddScoped<IUnitOfWork, DapperUnitOfWork>();
            }
            else
            {
                services.AddTransient(typeof(IRepository<>), typeof(FileRepository<>)); ;

                services.AddScoped(typeof(IUnitOfWork), typeof(FileUnitOfWork<>).MakeGenericType(options.LogModelType));
            }


            //register Controller
            RegisterHandle(services, options);

            //register Views
            RegisterViews(services);
        }

        private static void RegisterHandle(IServiceCollection services, LogPanelOptions opts)
        {
            var handles = Assembly.GetAssembly(typeof(LogPanelRoute)).GetTypes()
                .Where(x => typeof(LogPanelControllerBase).IsAssignableFrom(x) && x != typeof(LogPanelControllerBase));

            foreach (var handle in handles)
            {
                services.AddTransient(handle.MakeGenericType(opts.LogModelType));
            }
        }

        private static void RegisterViews(IServiceCollection services)
        {
            var views = Assembly.GetAssembly(typeof(LogPanelRoute)).GetTypes()
                .Where(x => typeof(RazorPage).IsAssignableFrom(x) && x != typeof(RazorPage));

            foreach (var view in views)
            {
                services.AddTransient(view);
            }
        }


    }

}