using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Favorites : EntityModel
    {
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
