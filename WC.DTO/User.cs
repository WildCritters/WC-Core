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
        public String Ip { get; set; }
        public DateTimeOffset LastLoggedAt { get; set; }
        public DateTimeOffset LastForumReadAt { get; set; }
        public String TimeZone { get; set; }
        public int IdRole { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Alias> Aliases { get; set; }
    }
}
