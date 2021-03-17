using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    [Table("Avatar")]
    public class Avatar : EntityModel
    {
        public string Extension { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Hash { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
