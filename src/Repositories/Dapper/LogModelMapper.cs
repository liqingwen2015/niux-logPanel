using System;
using DapperExtensions.Mapper;

namespace NiuX.LogPanel.Repositories.Dapper
{
    [Serializable]
    public sealed class LogModelMapper<T> : ClassMapper<T> where T : class
    {

        public LogModelMapper()
        {
            Table(LogPanelContext.StaticOptions.LogTableName);
            AutoMap();
        }

    }
}
