using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{

    public class Students
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        public virtual ICollection<StudentCousers> StudentCousers { get; set; }

    }
}