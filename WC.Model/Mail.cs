using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("Mail")]
    public class Mail : EntityModel
    {
        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }
        [ForeignKey("Receiverid")]
        public int Receiverid { get; set; }
        public virtual User Receiver { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool HasSeen { get; set; }
    }
}
