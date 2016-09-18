using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleObjectValidation.Models
{
    public class SomeModel
    {
        [Required]
        public string SomeString { get; set; }

        [Range(1, int.MaxValue)]
        public int SomeInt { get; set; }
    }
}
