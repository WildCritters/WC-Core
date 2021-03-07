using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("Function")]
    public class Function : EntityModel
    {
        public string Name { get; set; }
    }
}