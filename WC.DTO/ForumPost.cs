using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class ForumPost
    {
        public string Body { get; set; }
        public int TopicId { get; set; }
        public virtual ForumTopic Topic { get; set; }
    }
}
