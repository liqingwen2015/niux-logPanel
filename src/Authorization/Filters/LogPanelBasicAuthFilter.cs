using System;
using System.Net.Http.Headers;
using System.Text;

namespace NiuX.LogPanel.Authorization.Filters
{
    public class LogPanelBasicAuthFilter : ILogPanelAuthorizationFilter
    {
        public string UserName { get; set; }

        public string Password { get; set; }


        public LogPanelBasicAuthFilter(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public bool Authorization(LogPanelContext context)
        {
            var authorization = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrWhiteSpace(authorization))
            {
                context.HttpContext.Response.Headers.Add("WWW-Authenticate", "BASIC realm=\"api\"");
                context.HttpContext.Response.StatusCode = 401;
                return false;
            }
            var authHeader = AuthenticationHeaderValue.Parse(authorization);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
            var userName = credentials[0];
            var password = credentials[1];

            if (userName == UserName && password == Password)
            {
                return true;
            }

            context.HttpContext.Response.StatusCode = 401;
            context.HttpContext.Response.Headers.Add("WWW-Authenticate", "BASIC realm=\"api\"");
            return false;
        }
    }

}