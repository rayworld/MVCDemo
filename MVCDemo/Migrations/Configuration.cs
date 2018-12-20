namespace MVCDemo.Migrations
{
    using MVCDemo.Areas.Admin.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCDemo.DAL.BaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCDemo.DAL.BaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var sysusers = new List<TUser>
            {
                new TUser{Name="admin1",Password="1",EMail="casp@sina.com", CreateDate=System.DateTime.Now},
                new TUser{Name="admin2",Password="2",EMail="casp@sina.com", CreateDate=System.DateTime.Now},
                new TUser{Name="admin3",Password="3",EMail="casp@sina.com", CreateDate=System.DateTime.Now}
            };
            sysusers.ForEach(s => context.TUsers.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var sysroles = new List<TRole>
            {
                new TRole{Name="admin",Desc="admin"},
                new TRole{Name="user",Desc="User"}
            };
            sysroles.ForEach(r => context.TRoles.AddOrUpdate(c => c.Name, r));

            context.SaveChanges();

            var userroles = new List<TUserRole>
            {
                new TUserRole{
                    TUserID=sysusers.Single(u => u.Name == "admin1").ID,
                    TRoleID=sysroles.Single(r => r.Name == "user").ID
                },
                new TUserRole{
                    TUserID=sysusers.Single(u => u.Name == "admin1").ID,
                    TRoleID=sysroles.Single(r => r.Name == "admin").ID
                },
                new TUserRole{
                    TUserID=sysusers.Single(u => u.Name == "admin2").ID,
                    TRoleID=sysroles.Single(r => r.Name == "user").ID
                },
                new TUserRole{
                    TUserID=sysusers.Single(u => u.Name == "admin3").ID,
                    TRoleID=sysroles.Single(r => r.Name == "user").ID
                }
            };

            foreach (TUserRole tUserRole in userroles)
            {
                var db = context.TUserRoles.Where(t =>
                t.TUser.ID == tUserRole.TUserID &
                t.TRole.ID == tUserRole.TRoleID).SingleOrDefault();
                if (db == null)
                {
                    context.TUserRoles.Add(tUserRole);

                }
            }
            context.SaveChanges();
        }
    }
}
