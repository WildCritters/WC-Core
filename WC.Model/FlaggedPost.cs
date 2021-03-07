using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    [Table("FlaggedPost")]
    public class FlaggedPost : EntityModel
    {
        public string Reason { get; set; }
        public bool Resolved { get; set; }
        public DateTimeOffset ResolvedDate { get; set; }
        public string StaffComment { get; set; }
        public string StaffAction { get; set; }
        public bool DMailSent { get; set; }
        public int StaffuserId { get; set; }
        public virtual User StaffUser { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
