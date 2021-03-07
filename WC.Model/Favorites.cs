using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("Alias")]
    public class Favorites : EntityModel
    {
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
