using System.Collections.Generic;

namespace MVCDemo.Models
{

    public class Courses
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<StudentCousers> StuCousers { get; set; }
    }
}