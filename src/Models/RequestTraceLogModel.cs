namespace NiuX.LogPanel.Models
{
    public class RequestTraceLogModel : LogModel, IRequestTraceLogModel
    {
        public string TraceIdentifier { get; set; }
    }
}