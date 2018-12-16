namespace MVCDemo.Migrations
{
    using MVCDemo.Areas.Admin.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCDemo.DAL.BaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVCDemo.DAL.BaseContext";
        }

        protected override void Seed(MVCDemo.DAL.BaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var sysuser = new List<TUser>
            {
                new TUser{Name="admin1",Password="1",EMail="casp@sina.com"},
                new TUser{Name="admin2",Password="2",EMail="casp@sina.com"},
                new TUser{Name="admin3",Password="3",EMail="casp@sina.com"}
            };
            sysuser.ForEach(u => context.TUsers.Add(u));

            var sysrole = new List<TRole>
            {
                new TRole{Name="admin",Desc="admin"},
                new TRole{Name="user",Desc="User"}
            };
            sysrole.ForEach(r => context.TRoles.Add(r));

            context.SaveChanges();
        }
    }
}
