using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name:"SysUserRole")]
    public class UserRoleEntity
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        public virtual RoleEntity Role { get; set; }

        public virtual UserEntity User { get; set; }

    }
}