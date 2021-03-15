using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class NoteVersion : EntityModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Body { get; set; }
        public int Version { get; set; }
        public virtual Post Post { get; set; }
        public virtual Note Note { get; set; }
    }
}
