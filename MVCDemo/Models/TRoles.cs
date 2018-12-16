using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class TRoles
    {
        public int ID { get; set; }

        [Display(Name="角色名称")]
        [Required]
        [MaxLength=10]
        public string Name { get; set; }

        [Display(Name = "角色描述")]
        [MaxLength=50]
        public string Desc { get; set; }

        public virtual ICollection<TUserRoles> SysUserRole { get; set; }
    }
}