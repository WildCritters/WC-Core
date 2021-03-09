using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class PoolPost : EntityModel
    {
        public int Sequence { get; set; }
        public virtual Pool Pool { get; set; }
        public virtual Post Post { get; set; }
    }
}
