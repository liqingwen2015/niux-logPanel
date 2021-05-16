using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NiuX.LogPanel.Handlers;
using NiuX.LogPanel.Views;

namespace NiuX.LogPanel.Controllers
{
    public abstract class LogPanelControllerBase : ILogPanelHandler
    {
        protected LogPanelControllerBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public LogPanelContext Context { get; set; }

        public IServiceProvider ServiceProvider { get; }

        public Dictionary<string, object> ViewData { get; set; } = new Dictionary<string, object>();


        public virtual async Task<string> View(object? model = null, Type? viewType = null)
        {
            if (!(ServiceProvider.GetRequiredService(viewType ?? Context.Route.View) is RazorPage view))
            {
                throw new ArgumentException("view not found");
            }

            Context.HttpContext.Response.ContentType = "text/html";
            ViewData["PanelMapPath"] = Context.Options.PathMatch;
            ViewData["Brand"] = Context.Options.Brand;
            ViewData["View"] = Context.Route.View;

            if (model != null)
            {
                ViewData["Model"] = model;
            }

            view.Context = Context;
            view.ViewData = ViewData;

            return await view.ToString().ToTaskResult().ConfigureAwait(false);
        }


        public virtual string Json(object model)
        {
            Context.HttpContext.Response.ContentType = "text/json";
            return JsonConvert.SerializeObject(model);
        }
    }

}