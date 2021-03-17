using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("Alias")]
    public class Alias : EntityModel
    {
        public string Name { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
