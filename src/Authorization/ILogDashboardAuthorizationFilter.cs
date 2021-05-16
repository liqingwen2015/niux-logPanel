namespace NiuX.LogPanel.Authorization
{
    public interface ILogPanelAuthorizationFilter
    {
        bool Authorization(LogPanelContext context);
    }
}