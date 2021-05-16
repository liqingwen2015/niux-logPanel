using System.Collections.Generic;

namespace NiuX.LogPanel.Models
{
    public class PagedResultModel<T> where T : class, ILogModel
    {
        public PagedResultModel(int totalCount, IEnumerable<T> list)
        {
            TotalCount = totalCount;
            List = list;
        }

        public int TotalCount { get; set; }

        public IEnumerable<T> List { get; set; }
    }
}