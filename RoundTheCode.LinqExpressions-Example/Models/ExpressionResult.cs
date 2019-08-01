using RoundTheCode.LinqExpressions_Example.Data.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCode.LinqExpressions_Example.Models
{
    public partial class ExpressionResult
    {
        public ExpressionResult(IEnumerable<FilmEntity> anyExample, IEnumerable<FilmEntity> includeExample, IEnumerable<FilmTimeEntity> andOrExample)
        {
            AnyExample = anyExample;
            IncludeExample = includeExample;
            AndOrExample = andOrExample;
        }

        public virtual IEnumerable<FilmEntity> AnyExample { get; }

        public virtual IEnumerable<FilmEntity> IncludeExample { get; }

        public virtual IEnumerable<FilmTimeEntity> AndOrExample { get; }

    }
}
