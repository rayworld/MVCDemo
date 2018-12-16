using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class TUserRoles
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        public virtual TRoles SysRole { get; set; }

        public virtual TUsers SysUser { get; set; }



    }
}