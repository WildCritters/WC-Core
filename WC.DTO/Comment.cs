using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Comment : EntityModel
    {
        public DateTimeOffset PostedAt { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
        public string Ip { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
