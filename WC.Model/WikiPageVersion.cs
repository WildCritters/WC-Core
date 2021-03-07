using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    [Table("WikiPageVersion")]
    public class WikiPageVersion
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Version { get; set; }
        public string Ip { get; set; }
        public bool Locked { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int WikiId { get; set; }
        [ForeignKey("WikiId")]
        public virtual WikiPage Wiki { get; set; }
    }
}
