using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    [Table("ForumTopic")]
    public class ForumTopic : EntityModel
    {
        public string Title { get; set; }
        public int ResponseCount { get; set; }
        public bool Sticky { get; set; }
        public bool Locked { get; set; }
        public int Priority { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
