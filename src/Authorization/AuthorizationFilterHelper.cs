using System.Collections.Generic;
using System.Linq;

namespace NiuX.LogPanel.Authorization
{
    public class AuthorizationFilterHelper
    {
        public static bool Authorization(List<ILogPanelAuthorizationFilter> filters, LogPanelContext context) => filters.Count == 0 || filters.All(x => x.Authorization(context));
    }
}