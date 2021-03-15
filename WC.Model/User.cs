using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("User")]
    public class User : EntityModel
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Mail { get; set; }
        public string Ip { get; set; }
        public bool Banned { get; set; }
        public string BanReason { get; set; }
        public int Level { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}