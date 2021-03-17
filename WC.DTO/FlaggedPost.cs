using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class FlaggedPost : EntityModel
    {
        public string Reason { get; set; }
        public bool Resolved { get; set; }
        public DateTimeOffset ResolvedDate { get; set; }
        public string StaffComment { get; set; }
        public string StaffAction { get; set; }
        public bool DMailSent { get; set; }
        public virtual User StaffUser { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
