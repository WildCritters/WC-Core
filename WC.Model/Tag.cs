using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("Tag")]
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
