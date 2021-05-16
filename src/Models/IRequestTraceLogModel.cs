namespace NiuX.LogPanel.Models
{
    public interface IRequestTraceLogModel : ILogModel
    {
        string TraceIdentifier { get; set; }
    }
}