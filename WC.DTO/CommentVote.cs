using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class CommentVote
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
