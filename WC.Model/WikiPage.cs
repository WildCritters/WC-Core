using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("WikiPage")]
    public class WikiPage : EntityModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Version { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public string Ip { get; set; }
        public bool Locked { get; set; }
    }
}
