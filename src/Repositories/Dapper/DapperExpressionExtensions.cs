using System;
using System.Linq.Expressions;
using DapperExtensions;
using NiuX.LogPanel.Models;

namespace NiuX.LogPanel.Repositories.Dapper
{
    internal static class DapperExpressionExtensions
    {

        public static IPredicate ToPredicateGroup<T>(this Expression<Func<T, bool>> expression) where T : class, ILogModel
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var dev = new DapperExpressionVisitor<T>();

            IPredicate pg = dev.Process(expression);

            return pg;
        }
    }
}
