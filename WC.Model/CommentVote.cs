using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("CommentVote")]
    public class CommentVote : EntityModel
    {
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
