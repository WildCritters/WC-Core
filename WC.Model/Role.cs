using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model
{
    [Table("Role")]
    public class Role : EntityModel
    {
        public string Name { get; set; }
    }
}