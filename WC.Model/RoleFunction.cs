using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("RoleFunction")]
    public class RoleFunction : EntityModel
    {
        public int RoleId { get; set; }  
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public int FunctionId { get; set; }
        [ForeignKey("FunctionId")]
        public Function Function { get; set; }   
    }
}