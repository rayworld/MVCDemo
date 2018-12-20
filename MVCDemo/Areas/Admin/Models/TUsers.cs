using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Areas.Admin.Models
{
    public class TUser
    {
        public int ID { get; set; }

        [Display(Name = "用户名称")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "邮箱")]
        [MaxLength(50)]
        [Required]
        public string EMail { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd hh:mm:ss}",ApplyFormatInEditMode =true)]
        public DateTime CreateDate { get; set; }
        public virtual ICollection<TUserRole> TUserRoles { get; set; }
    }
}