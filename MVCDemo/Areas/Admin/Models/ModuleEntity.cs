using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name: "SysModule")]
    public class ModuleEntity
    {
        [Display(Name = "模块编号")]
        public int ID { get; set; }

        [Display(Name = "模块名称")]
        [MaxLength(50, ErrorMessage = "模块名称超长")]
        public string Name { get; set; }

        [Display(Name = "模块描述")]
        [MaxLength(50, ErrorMessage = "模块描述超长")]
        [Column(name: "ModuleDesc")]
        public string Desc { get; set; }

        [Display(Name = "上级节点")]
        public int ParentID { get; set; }

        public virtual ICollection<ModulePremissionEntity> ModulePremissions { get; set; }
    }
}