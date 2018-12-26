using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Areas.Admin.Models
{
    [Table(name:"SysDept")]
    public class DeptEntity
    {
        [Display(Name = "部门编号")]
        public int ID { get; set; }

        [Display(Name = "部门名称")]
        [MaxLength(50,ErrorMessage ="部门名称超长")]
        public string Name { get; set; }

        [Display(Name = "部门描述")]
        [MaxLength(50, ErrorMessage = "部门描述超长")]
        [Column(name:"DeptDesc")]
        public string Desc { get; set; }

        [Display(Name = "显示顺序")]
        public int SortOrder { get; set; }

        [Display(Name = "上级节点")]
        public int ParantID { get; set;}

        
        public virtual ICollection<UserEntity> Users { get; set; }

    }
}