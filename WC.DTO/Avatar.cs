using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Avatar
    {
        public string Extension { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Hash { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
