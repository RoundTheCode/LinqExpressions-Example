using RoundTheCode.LinqExpressions_Example.Data;
using RoundTheCode.LinqExpressions_Example.Data.Models.Types;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RoundTheCode.LinqExpressions_Example.Expressions
{
    public partial class IncludeExpression : ExpressionBase<FilmEntity>
    {
        public override IQueryable<FilmEntity> GetExampleQuery(LinqExpressionsDbContext context)
        {
            var expression = GetExpression(context);

            // Store the filter as a dynamic query.
            return context.FilmEntities.Where(expression);
        }

        protected override Expression<Func<FilmEntity, bool>> GetExpression(LinqExpressionsDbContext context)
        {
            var beginTime = DateTimeOffset.Parse("2019-08-03 12:30");
            var endTime = DateTimeOffset.Parse("2019-08-03 16:30");

            // We want to build the expression for the "Where" clause

            // Example of Query we will eventually run.
            // context.FilmEntities.Include("FilmTimes").Where(f.FilmTimes.Any(ft => ft.StartTime >= beginTime && ft.StartTime < endTime));

            var fParameter = Expression.Parameter(typeof(FilmEntity), "f"); // f =>

            // Get Film Times between beginTime and endTime
            var fFilmTimeProperty = Expression.Property(fParameter, "FilmTimes"); // f.FilmTimes

            // Time to build up the clause in the ANY field
            var ftParameter = Expression.Parameter(typeof(FilmTimeEntity), "ft"); // ft =>

            var ftStartTimeProperty = Expression.Property(ftParameter, "StartTime"); // ft.StartTime
            var ftBeginTimeClause = Expression.GreaterThanOrEqual(ftStartTimeProperty, Expression.Constant(beginTime)); // ft.StartTime >= startTime
            var ftEndTimeClause = Expression.LessThan(ftStartTimeProperty, Expression.Constant(endTime)); // ft.StartTime < endTime

            // Builds up the AND expression
            var ftFullQueryExpression = Expression.AndAlso(ftBeginTimeClause, ftEndTimeClause); // ft => ft.StartTime >= beginTime && ft.StartTime < endTime

            // Make the Lambda Expression for Film Time
            var ftLambda = Expression.Lambda<Func<FilmTimeEntity, bool>>(ftFullQueryExpression, ftParameter);

            // Join in an ANY statement
            var anyMethod = typeof(Enumerable).GetMethods().FirstOrDefault(method => method.Name == "Any" && method.GetParameters().Count() == 2); // Use reflection to find the ANY method (We use Enumerable for collections)
            var anyFilmTimeMethod = anyMethod.MakeGenericMethod(typeof(FilmTimeEntity)); // Any is a generic method, so create a method specific to FilmTimeEntity

            var anyCall = Expression.Call(anyFilmTimeMethod, fFilmTimeProperty, ftLambda); // FilmTimes.Any(ft => ft.StartTime >= beginTime && ft.StartTime < endTime)

            // Return the lamba expression for film so we can put in the where clause.
            return Expression.Lambda<Func<FilmEntity, bool>>(anyCall, fParameter);
        }

    }
}
