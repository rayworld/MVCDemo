using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name:"SysUser")]
    public class UserEntity
    {
        public int ID { get; set; }

        [Display(Name = "用户名称")]
        [MaxLength(50,ErrorMessage = "用户名称长度过长")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [MaxLength(50,ErrorMessage = "密码长度过长")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "邮箱")]
        [MaxLength(50,ErrorMessage = "邮箱长度过长")]
        [Required]
        public string EMail { get; set; }

        [Display(Name = "创建时间")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime CreateDate { get; set; }
        
        [Display(Name = "部门")]
        public int? TitleID { get; set; }

        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }

        public virtual DeptEntity Dept { get; set; }
    }
}