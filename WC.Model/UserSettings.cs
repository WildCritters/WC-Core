using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    [Table("UserSettings")]
    public class UserSettings : EntityModel
    {
        public bool ReceiveMailNotifications { get; set; }
        public int CommentThreshold { get; set; }
        public bool AlwaysResizeImages  { get; set; }
        public string DefaultImageSize { get; set; }
        public string Tags { get; set; }
        public string BlacklistTags { get; set; }
        public string TimeZone { get; set; }
        public bool SafeMode { get; set; }
        public string Theme { get; set; }
        public string BlacklistUsers { get; set; }
        public string SignatureTitle { get; set; }
        public string SignatureBody { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
