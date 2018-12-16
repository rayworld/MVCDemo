using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class TUsers
    {
        public int ID { get; set; }

        [Display(Name = "用户名称")]
        [Required]
        [MaxLength=10]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<TUserRoles> SysUserRole { get; set; }
    }
}