using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name: "SysRole")]
    public class RoleEntity
    {
        [Display(Name = "角色编号")]
        public int ID { get; set; }

        [Display(Name="角色名称")]
        [MaxLength(50,ErrorMessage ="角色名称超长")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "角色描述")]
        [Column(name:"RoleDesc")]
        [MaxLength(50, ErrorMessage = "角色描述超长")]
        public string Desc { get; set; }

        public virtual ICollection<UserRoleEntity> SysUserRoles { get; set; }

        public virtual ICollection<RoleModulePremissionEntity> RoleModulePremissions { get; set; }
    }
}