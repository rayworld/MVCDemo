namespace MVCDemo.Models
{

    public class StudentCousers
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        public virtual Students Student { get; set; }

        public virtual Courses Course { get; set; }
    }
}