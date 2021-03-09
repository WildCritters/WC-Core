using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Mail : EntityModel
    {
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool HasSeen { get; set; }
    }
}
