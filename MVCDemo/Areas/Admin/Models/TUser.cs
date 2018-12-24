using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Areas.Admin.Models
{
    public class TUser
    {
        public int ID { get; set; }

        [Display(Name = "用户名称")]
        [MaxLength(50,ErrorMessage = "用户名称长度不能超过50个字符")]
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

        [Display(Name = "创建时间")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "部门")]
        public int? TDeptID { get; set; }

        public virtual ICollection<TUserRole> TUserRoles { get; set; }

        public virtual TDept TDept { get; set; }
    }
}