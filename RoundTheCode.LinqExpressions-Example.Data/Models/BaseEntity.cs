using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoundTheCode.LinqExpressions_Example.Data.Models
{
    public partial class BaseEntity : IBaseEntity
    {
        [Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public virtual int Id { get; set; }
    }
}
