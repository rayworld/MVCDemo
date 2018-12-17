namespace MVCDemo.Areas.Admin.Models
{
    public class TUserRole
    {
        public int ID { get; set; }

        public int TUserID { get; set; }

        public int TRoleID { get; set; }

        public virtual TRole TRole { get; set; }

        public virtual TUser TUser { get; set; }



    }
}