using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Areas.Admin.Models
{
    public class TRole
    {
        public int ID { get; set; }

        [Display(Name="角色名称")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "角色描述")]
        public string Desc { get; set; }

        public virtual ICollection<TUserRole> TUserRole { get; set; }
    }
}