using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class TRoles
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public virtual ICollection<TUserRoles> SysUserRole { get; set; }
    }
}