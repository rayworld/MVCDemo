using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name:"SysRolePremission")]
    public class RolePremissionEntity
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public int PremissionID { get; set; }

        public virtual RoleEntity Role { get; set; }

        public virtual PremissionEntity Premission { get; set; }
    }
}