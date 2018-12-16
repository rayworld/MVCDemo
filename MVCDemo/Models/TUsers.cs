using System.Collections.Generic;

namespace MVCDemo.Models
{
    public class TUsers
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<TUserRoles> SysUserRole { get; set; }
    }
}