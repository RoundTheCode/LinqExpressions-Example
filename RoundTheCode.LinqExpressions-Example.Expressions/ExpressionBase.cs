using RoundTheCode.LinqExpressions_Example.Data;
using RoundTheCode.LinqExpressions_Example.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RoundTheCode.LinqExpressions_Example.Expressions
{
    public abstract partial class ExpressionBase<TEntity>
        where TEntity : class, IBaseEntity
    {
        protected abstract Expression<Func<TEntity, bool>> GetExpression(LinqExpressionsDbContext context);

        public abstract IQueryable<TEntity> GetExampleQuery(LinqExpressionsDbContext context);
    }
}
