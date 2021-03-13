using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Note : EntityModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Body { get; set; }
        public int Version { get; set; }
        public int IdPost { get; set; }
        public Post Post { get; set; }
    }
}
