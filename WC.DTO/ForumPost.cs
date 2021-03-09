using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class ForumPost : EntityModel
    {
        public string Body { get; set; }
        public virtual ForumTopic Topic { get; set; }
    }
}
