using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoundTheCode.LinqExpressions_Example.Data.Models.Types
{
    public partial class FilmEntity : BaseEntity
    {
        [MaxLength(100)]
        public virtual string Name { get; set; }

        public virtual ICollection<FilmTimeEntity> FilmTimes { get; set; }
    }
}
