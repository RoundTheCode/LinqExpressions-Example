using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoundTheCode.LinqExpressions_Example.Data.Models.Types
{
    [Table("FilmTime")]
    public partial class FilmTimeEntity : BaseEntity
    {
        public virtual int FilmId { get; set; }

        public virtual DateTimeOffset StartTime { get; set; }

        [ForeignKey("FilmId")]
        public virtual FilmEntity Film { get; set; }
    }
}
