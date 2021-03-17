using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    [Table("UserData")]
    public class UserData : EntityModel
    {
        public DateTimeOffset LastLoggedAt { get; set; }
        public DateTimeOffset LastForumReadAt { get; set; }
        public string RecentTags { get; set; }
        public int PostUploadCount { get; set; }
        public int PostUpdateCount { get; set; }
        public int NoteUpdateCount { get; set; }
        public int FavouriteCount { get; set; }
        public int NotificationActive { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
