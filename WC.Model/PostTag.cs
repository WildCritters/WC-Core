using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("PostTag")]
    public class PostTag : EntityModel
    {
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
