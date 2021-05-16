using System.Collections.Generic;
using System.Linq;

namespace NiuX.LogPanel.Authorization.Filters
{
    public class LogPanelRoleAuthorizeFilter : ILogPanelAuthorizationFilter
    {
        public List<string> RoleNames { get; set; }

        public LogPanelRoleAuthorizeFilter(List<string> roleNames)
        {
            RoleNames = roleNames;
        }
        public bool Authorization(LogPanelContext context)
        {
            return RoleNames.Any(roleName => context.HttpContext.User.IsInRole(roleName));
        }
    }
}