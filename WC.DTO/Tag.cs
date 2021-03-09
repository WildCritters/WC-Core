using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Tag : EntityModel
    {
        public string Name { get; set; }
        public int PostCount { get; set; }
        public int Category { get; set; }
        public bool Ambigous { get; set; }
        public string RelatedTags { get; set; }
        public DateTimeOffset RelatedTagsUpdated { get; set; }
    }
}
