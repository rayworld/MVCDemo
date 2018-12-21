using System.Collections.Generic;

namespace MVCDemo.Areas.Admin.Models
{
    public class TDept
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int SortOrder { get; set; }

        public int ParantID { get; set;}

        public virtual ICollection<TUser> TUsers { get; set; }
    }
}