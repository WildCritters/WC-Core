using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.API.Model.Note
{
    public class UpdateNoteRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Body { get; set; }
        public int Version { get; set; }
        public int Id { get; set; }
    }
}
