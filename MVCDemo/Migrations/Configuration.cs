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
            var sysdepts = new List<DeptEntity>
            {
                new DeptEntity{Name = "总公司", Desc = "总公司", SortOrder = 0, ParantID = 0 }
                //new DeptEntity{Name = "市场部", Desc = "市场部", SortOrder = 1, ParantID = 0 },
                //new DeptEntity{Name = "技术部", Desc = "技术部", SortOrder = 2, ParantID = 0 },
                //new DeptEntity{Name = "销售部", Desc = "销售部", SortOrder = 3, ParantID = 0 }
            };

            sysdepts.ForEach(d => context.Depts.AddOrUpdate(p => p.Name, d));
                       
            context.SaveChanges();

            var sysdepts1 = new List<DeptEntity>
            {
                new DeptEntity{Name = "市场部", Desc = "市场部", SortOrder = 1, ParantID = context.Depts.Single(e => e.Name == "总公司").ID },
                new DeptEntity{Name = "技术部", Desc = "技术部", SortOrder = 2, ParantID = context.Depts.Single(e => e.Name == "总公司").ID },
                new DeptEntity{Name = "销售部", Desc = "销售部", SortOrder = 3, ParantID = context.Depts.Single(e => e.Name == "总公司").ID }
            };

            sysdepts1.ForEach(d => context.Depts.AddOrUpdate(p => p.Name, d));

            context.SaveChanges();
            
            //var sysusers = new List<UserEntity>
            //{
            //    new UserEntity { Name = "admin1", Password = "1", EMail = "casp1@sina.com", CreateDate = System.DateTime.Now },
            //    new UserEntity { Name = "admin2", Password = "2", EMail = "casp2@sina.com", CreateDate = System.DateTime.Now },
            //    new UserEntity { Name = "admin3", Password = "3", EMail = "casp3@sina.com", CreateDate = System.DateTime.Now },
            //    new UserEntity { Name = "admin4", Password = "4", EMail = "casp4@sina.com", CreateDate = System.DateTime.Now },
            //    new UserEntity { Name = "admin5", Password = "5", EMail = "casp5@sina.com", CreateDate = System.DateTime.Now },
            //    new UserEntity { Name = "admin6", Password = "6", EMail = "casp6@sina.com", CreateDate = System.DateTime.Now }
            //    new UserEntity { Name = "admin7", Password = "7", EMail = "casp7@sina.com", CreateDate = System.DateTime.Now },
            //    new UserEntity { Name = "admin8", Password = "8", EMail = "casp8@sina.com", CreateDate = System.DateTime.Now },
            //    new UserEntity { Name = "admin9", Password = "9", EMail = "casp9@sina.com", CreateDate = System.DateTime.Now }
            //};
            //sysusers.ForEach(s => context.Users.AddOrUpdate(p => p.Name, s));
            ////context.SaveChanges();

            //var sysroles = new List<RoleEntity>
            //{
            //    new RoleEntity{Name="admin",Desc="admin"},
            //    new RoleEntity{Name="user",Desc="User"}
            //};
            //sysroles.ForEach(r => context.Roles.AddOrUpdate(c => c.Name, r));

            ////context.SaveChanges();

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
            //context.SaveChanges();
        }
    }
}