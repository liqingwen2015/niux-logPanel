using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NiuX.LogPanel.Infrastructure
{
    public static class LogPanelEmbeddedFileHelper
    {
        private static readonly Dictionary<string, string> ResponseType = new Dictionary<string, string>
        {
            { ".css","text/css"},
            { ".js","application/javascript"},
            {".woff2","font/woff2" },
            {".woff","font/woff" },
            {".ttf","application/octet-stream" },
        };

        private static readonly Assembly Assembly;

        static LogPanelEmbeddedFileHelper() => Assembly = Assembly.GetExecutingAssembly();

        public static async Task IncludeEmbeddedFile(HttpContext context, string path)
        {

            context.Response.OnStarting(() =>
            {
                if (context.Response.StatusCode == (int)HttpStatusCode.OK)
                {
                    context.Response.ContentType = ResponseType[Path.GetExtension(path)];
                }

                return Task.CompletedTask;
            });

            //Assembly.GetManifestResourceInfo()
            
            await using var inputStream = Assembly.GetManifestResourceStream($"{LogPanelConsts.Root}.wwwroot.{path[1..]}");
            
            if (inputStream == null)
            {
                throw new ArgumentException($"Resource with name {path[1..]} not found in assembly {Assembly}.");
            }
            
            await inputStream.CopyToAsync(context.Response.Body).ConfigureAwait(false);
        }
    }

}