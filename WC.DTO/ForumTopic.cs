using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class ForumTopic : EntityModel
    {
        public string Title { get; set; }
        public int ResponseCount { get; set; }
        public bool Sticky { get; set; }
        public bool Locked { get; set; }
        public int Priority { get; set; }
        public virtual User User { get; set; }
    }
}
