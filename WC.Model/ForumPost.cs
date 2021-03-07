using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    [Table("ForumPost")]
    public class ForumPost : EntityModel
    {
        public string Body { get; set; }
        public int TopicId { get; set; }
        [ForeignKey("TopicId")]
        public virtual ForumTopic Topic { get; set; }
    }
}
