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

            var sysusers = new List<UserEntity>
            {
                new UserEntity{Name="admin1",Password="1",EMail="casp@sina.com", CreateDate=System.DateTime.Now},
                new UserEntity{Name="admin2",Password="2",EMail="casp@sina.com", CreateDate=System.DateTime.Now},
                new UserEntity{Name="admin3",Password="3",EMail="casp@sina.com", CreateDate=System.DateTime.Now}
            };
            sysusers.ForEach(s => context.Users.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var sysroles = new List<RoleEntity>
            {
                new RoleEntity{Name="admin",Desc="admin"},
                new RoleEntity{Name="user",Desc="User"}
            };
            sysroles.ForEach(r => context.Roles.AddOrUpdate(c => c.Name, r));

            context.SaveChanges();

            //var userroles = new List<UserRoleEntity>
            //{
            //    new UserRoleEntity{
            //        UserID=sysusers.Single(u => u.Name == "admin1").ID,
            //        RoleID=sysroles.Single(r => r.Name == "user").ID
            //    },
            //    new UserRoleEntity{
            //        UserID=sysusers.Single(u => u.Name == "admin1").ID,
            //        RoleID=sysroles.Single(r => r.Name == "admin").ID
            //    },
            //    new UserRoleEntity{
            //        UserID=sysusers.Single(u => u.Name == "admin2").ID,
            //        RoleID=sysroles.Single(r => r.Name == "user").ID
            //    },
            //    new UserRoleEntity{
            //        UserID=sysusers.Single(u => u.Name == "admin3").ID,
            //        RoleID=sysroles.Single(r => r.Name == "user").ID
            //    }
            //};

            //foreach (UserRoleEntity tUserRole in userroles)
            //{
            //    var db = context.UserRoles.Where(t =>
            //    t.User.ID == tUserRole.UserID &
            //    t.Role.ID == tUserRole.RoleID).SingleOrDefault();
            //    if (db == null)
            //    {
            //        context.UserRoles.Add(tUserRole);

            //    }
            //}
            context.SaveChanges();
        }
    }
}
