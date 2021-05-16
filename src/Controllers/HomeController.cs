using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DapperExtensions;
using NiuX.Extensions;
using NiuX.LogPanel.Handlers;
using NiuX.LogPanel.Handlers.LogCharts;
using NiuX.LogPanel.Infrastructure;
using NiuX.LogPanel.Infrastructure.Extensions;
using NiuX.LogPanel.Models;
using NiuX.LogPanel.Repositories;
using NiuX.LogPanel.Views.Home;

namespace NiuX.LogPanel.Controllers
{
    public class HomeController<T> : LogPanelControllerBase where T : class, ILogModel
    {
        private readonly IRepository<T> _logRepository;

        public HomeController(IServiceProvider serviceProvider, IRepository<T> logRepository) : base(serviceProvider)
        {
            _logRepository = logRepository;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public async Task<string> Index()
        {
            ViewData["panelNav"] = "active";
            ViewData["basicLogNav"] = "";
            var result = await _logRepository.GetPageListAsync(1, 10, sorts: new[] { new Sort { Ascending = false, PropertyName = "Id" } }).ConfigureAwait(false);

            ViewData["unique"] = (await _logRepository.UniqueCountAsync().ConfigureAwait(false)).Count;

            var now = DateTime.Now;
            var weeHours = now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            ViewData["todayCount"] = await _logRepository.CountAsync(x => x.LongDate >= now.Date && x.LongDate <= weeHours).ConfigureAwait(false);

            var hour = now.AddHours(-1);
            ViewData["hourCount"] = await _logRepository.CountAsync(x => x.LongDate >= hour && x.LongDate <= now);
            ViewData["allCount"] = await _logRepository.CountAsync();

            //Chart Data
            ViewData["ChartData"] = (await LogChartFactory.GetLogChart(ChartDataType.Hour).GetCharts(_logRepository).ConfigureAwait(false)).ToJsonString();

            return await View(result).ConfigureAwait(false);
        }

        public async Task<string> GetLogChart(GetChartDataInput input)
        {
            return Json(await LogChartFactory.GetLogChart(input.ChartDataType).GetCharts(_logRepository).ConfigureAwait(false));
        }

        /// <summary>
        /// 基本
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> Basic(SearchLogInput? input)
        {
            ViewData["panelNav"] = "";
            ViewData["basicLogNav"] = "active";
            input ??= new SearchLogInput();
            var result = await GetPageResult(input);
            ViewData["logs"] = await View(result.List, typeof(LogList));
            ViewData["page"] = HtmlHelper.Page(input.Page, input.PageSize, result.TotalCount);
            return await View();
        }

        public async Task<string> SearchLog(SearchLogInput? input)
        {
            input ??= new SearchLogInput();
            var result = await GetPageResult(input);
            ViewData["totalCount"] = result.TotalCount;

            return Json(new SearchLogModel
            {
                Page = HtmlHelper.Page(input.Page, input.PageSize, result.TotalCount),
                Html = await View(result.List, typeof(LogList)).ConfigureAwait(false)
            });
        }

        private async Task<PagedResultModel<T>> GetPageResult(SearchLogInput input)
        {
            Expression<Func<T, bool>> expression = x => x.Id != 0;

            expression = expression.AndIf(input.ToDay, () =>
             {
                 var now = DateTime.Now;
                 var weeHours = now.Date.AddHours(23).AddMinutes(59);
                 return x => x.LongDate >= now.Date && x.LongDate <= weeHours;
             });

            expression = expression.AndIf(input.Hour, () =>
             {
                 var now = DateTime.Now;
                 var hour = now.AddHours(-1);
                 return x => x.LongDate >= hour && x.LongDate <= now;
             });

            expression = expression.AndIf(input.StartTime.HasValue, () => x => x.LongDate >= input.StartTime!.Value);

            expression = expression.AndIf(input.EndTime.HasValue, () => x => x.LongDate <= input.EndTime!.Value);

            expression = expression.AndIf(input.Level.IsNotNullOrNotWhiteSpace(), () => x => x.Level.IsEqual(input.Level, StringComparison.OrdinalIgnoreCase));

            expression = expression.AndIf(input.Message.IsNotNullOrNotWhiteSpace(), () => x => x.Message.Contains(input.Message));

            if (input.Unique)
            {
                var (count, ids) = await _logRepository.UniqueCountAsync(expression);
                return new PagedResultModel<T>(count, await _logRepository.GetPageListAsync(input.Page, input.PageSize, expression, new[] { new Sort { Ascending = false, PropertyName = "Id" } }, ids));
            }

            var logs = await _logRepository.GetPageListAsync(input.Page, input.PageSize, expression, new[] { new Sort { Ascending = false, PropertyName = "Id" } });

            var totalCount = await _logRepository.CountAsync(expression);


            return new PagedResultModel<T>(totalCount, logs);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<string> Detail(T info)
        {
            return await View(info);
        }

        public async Task<string> RequestTrace(LogModelInput input)
        {
            var log = await _logRepository.FirstOrDefaultAsync(x => x.Id == input.Id);

            var traceIdentifier = ((IRequestTraceLogModel)log).TraceIdentifier;

            if (string.IsNullOrWhiteSpace(traceIdentifier))
            {
                return await View(new List<T>(), typeof(TraceLogList));
            }

            return await View((await _logRepository
                .RequestTraceAsync(log))
                .OrderBy(x => x.LongDate).ToList(), typeof(TraceLogList));
        }
    }

}