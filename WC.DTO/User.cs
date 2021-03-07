using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class User
    {
        public long Id { get; set; }
        public String UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public String Mail { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
        public DateTimeOffset LastLoggedAt { get; set; }
        public DateTimeOffset LastForumReadAt { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public Guid ActivationCode { get; set; }
        public String TimeZone { get; set; }
        public String Ip { get; set; }
        public bool Active { get; set; } 
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
