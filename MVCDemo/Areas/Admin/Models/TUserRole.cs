﻿namespace MVCDemo.Areas.Admin.Models
{
    public class TUserRole
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        public virtual TRole TRole { get; set; }

        public virtual TUser TUser { get; set; }



    }
}