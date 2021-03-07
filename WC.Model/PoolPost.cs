using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    [Table("PoolPost")]
    [Index(nameof(PoolId), IsUnique = true)]
    [Index(nameof(PostId), IsUnique = true)]
    public class PoolPost : EntityModel
    {
        public int Sequence { get; set; }
        public int PoolId { get; set; }
        [ForeignKey("PoolId")]
        public virtual Pool Pool { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
