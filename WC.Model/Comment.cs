using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("Comments")]
    //[Index(nameof(PostId))]
    public class Comment : EntityModel
    {
        public DateTimeOffset PostedAt { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
        public string Ip { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
