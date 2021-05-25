using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NiuX.Extensions;
using NiuX.LogPanel.Authorization;
using NiuX.LogPanel.Controllers;
using NiuX.LogPanel.Handlers;
using NiuX.LogPanel.Infrastructure;
using NiuX.LogPanel.Repositories;
using NiuX.LogPanel.Routes;

namespace NiuX.LogPanel
{
    public class LogPanelMiddleware
    {
        private readonly RequestDelegate _next;

        public LogPanelMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            using var scope = httpContext.RequestServices.CreateScope();
            var opts = scope.ServiceProvider.GetService<LogPanelOptions>();

            var requestUrl = httpContext.Request.Path.Value;

            //EmbeddedFile
            if (requestUrl.Contains("css") || requestUrl.Contains("js") || requestUrl.Contains("woff"))
            {
                await LogPanelEmbeddedFileHelper.IncludeEmbeddedFile(httpContext, requestUrl);
                return;
            }

            // Find Router
            var router = LogPanelRouteProvider.Routes.FindRoute(requestUrl);

            if (router == null)
            {
                httpContext.Response.StatusCode = 404;
                return;
            }

            // Authorization
            if (!await AuthorizeHelper.AuthorizeAsync(httpContext, opts.AuthorizeData))
            {
                return;
            }

            var logPanelContext = new LogPanelContext(httpContext, router,
                opts);

            if (!AuthorizationFilterHelper.Authorization(opts.AuthorizationFiles, logPanelContext))
            {
                if (httpContext.Response.StatusCode == (int)HttpStatusCode.OK)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
                return;
            }

            using var uow = scope.ServiceProvider.GetService<IUnitOfWork>();
            await uow?.Open();

            //Activate Controller
            var controllerType = Assembly.GetAssembly(typeof(ILogPanelHandler)).GetTypes().First(x => x.Name.StartsWith(router.Controller + "Controller"));

            if (scope.ServiceProvider.GetRequiredService(controllerType.MakeGenericType(opts.LogModelType)) is not ILogPanelHandler handler)
            {
                httpContext.Response.StatusCode = 404;
                return;
            }


            handler.Context = logPanelContext;

            string html;

            var method = handler.GetType().GetMethod(router.Action);
            var parametersLength = method!.GetParameters().Length;

            if (parametersLength == 0)
            {
                html = await (Task<string>)method.Invoke(handler, null);
            }
            else
            {
                if (httpContext.Request.ContentLength == null && httpContext.Request.Query.Count <= 0)
                {
                    html = await (Task<string>)method.Invoke(handler, new object[] { null! });
                }
                else
                {
                    object args;
                    if (httpContext.Request.Query.Count > 0)
                    {
                        var dict = new Dictionary<string, string>();
                        httpContext.Request.Query.ToList().ForEach(x => dict.Add(x.Key, x.Value));
                        args = JsonConvert.DeserializeObject(dict.ToJsonString(), method.GetParameters().First().ParameterType);
                    }
                    else
                    {
                        // ReSharper disable once PossibleInvalidOperationException
                        var bytes = new byte[(int)httpContext.Request.ContentLength];
                        await httpContext.Request.Body.ReadAsync(bytes, 0, (int)httpContext.Request.ContentLength);
                        var requestJson = Encoding.Default.GetString(bytes);

                        args = JsonConvert.DeserializeObject(requestJson, method.GetParameters().First().ParameterType);

                    }

                    html = await (Task<string>)method.Invoke(handler, new[] { args });

                }
            }

            await httpContext.Response.WriteAsync(html);
        }
    }

}