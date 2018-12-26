using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name:"SysModulePremission")]
    public class ModulePremissionEntity
    {
        public int ID { get; set; }

        public int ModuleID { get; set; }

        public int PremissionID { get; set; }

        public virtual ModuleEntity Module { get; set; }

        public virtual PremissionEntity Premission { get; set; }
    }
}