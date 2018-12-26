using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name: "SysPremission")]
    public class PremissionEntity
    {
        [Display(Name="权限编号")]
        public int ID { get; set; }

        [Display(Name = "权限名称")]
        public string Name { get; set; }

        [Display(Name = "权限描述")]
        public string PremissionDesc { get; set; }

        public virtual ICollection<ModuleEntity> Modules { get; set; }

        public virtual ICollection<ModulePremissionEntity> ModulePremissions { get; set; }

    }
}