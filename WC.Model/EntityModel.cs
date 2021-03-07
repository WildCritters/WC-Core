using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Model
{
    public abstract class EntityModel
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public bool Active { get; set; }
    }
}
