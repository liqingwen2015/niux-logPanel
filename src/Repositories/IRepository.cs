﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DapperExtensions;
using NiuX.LogPanel.Models;

namespace NiuX.LogPanel.Repositories
{
    public interface IRepository<T> where T : class, ILogModel
    {
        Task<IEnumerable<T>> RequestTraceAsync(T model);

        Task<(int Count, List<int> ids)> UniqueCountAsync(Expression<Func<T, bool>> predicate = null);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null);

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

        Task<IEnumerable<T>> GetPageListAsync(int page, int size, Expression<Func<T, bool>> predicate = null, Sort[] sorts = null, List<int> uniqueIds = null);

    }
}