using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.DTO
{
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
        public virtual Role Role { get; set; }
    }
}
