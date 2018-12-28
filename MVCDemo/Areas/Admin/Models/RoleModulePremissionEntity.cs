using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name:"SysRoleModulePremission")]
    public class RoleModulePremissionEntity
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public int ModulePremissionID { get; set; }

        public virtual RoleEntity Role { get; set; }

        public virtual ModulePremissionEntity ModulePremission { get; set; }
    }
}