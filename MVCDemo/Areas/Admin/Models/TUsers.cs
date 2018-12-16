using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Areas.Admin.Models
{
    public class TUser
    {
        public int ID { get; set; }

        [Display(Name = "用户名称")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "邮箱")]
        [Required]
        public string EMail { get; set; }

        public virtual ICollection<TUserRole> TUserRole { get; set; }
    }
}