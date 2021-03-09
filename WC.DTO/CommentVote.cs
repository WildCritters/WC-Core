using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class CommentVote : EntityModel
    {
        public virtual Post Post { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
    }
}
