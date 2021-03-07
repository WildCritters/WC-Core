using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class WikiPage
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Version { get; set; }
        public string Ip { get; set; }
        public bool Locked { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
