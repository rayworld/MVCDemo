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

            //部门表初始化
            // 对于需要自连接的表，只能一级级的加入，需要得到上级的ID
            var sysdepts = new List<DeptEntity>
            {
                new DeptEntity{Name = "总公司", Desc = "总公司", SortOrder = 0, ParantID = 0 }
            };
            sysdepts.ForEach(d => context.Depts.AddOrUpdate(p => p.Name, d));
            context.SaveChanges();

            //第二级
            var sysdepts1 = new List<DeptEntity>
            {
                new DeptEntity{Name = "市场部", Desc = "市场部", SortOrder = 1, ParantID = context.Depts.Single(e => e.Name == "总公司").ID },
                new DeptEntity{Name = "技术部", Desc = "技术部", SortOrder = 2, ParantID = context.Depts.Single(e => e.Name == "总公司").ID },
                new DeptEntity{Name = "销售部", Desc = "销售部", SortOrder = 3, ParantID = context.Depts.Single(e => e.Name == "总公司").ID },
                new DeptEntity{Name = "财务部", Desc = "财务部", SortOrder = 4, ParantID = context.Depts.Single(e => e.Name == "总公司").ID }
            };
            sysdepts1.ForEach(d => context.Depts.AddOrUpdate(p => p.Name, d));
            context.SaveChanges();

            //用户表初始化
            var sysusers = new List<UserEntity>
            {
                new UserEntity { Name = "admin1", Password = "1", EMail = "casp1@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "技术部").ID },
                new UserEntity { Name = "admin2", Password = "2", EMail = "casp2@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "总公司").ID },
                new UserEntity { Name = "admin3", Password = "3", EMail = "casp3@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "财务部").ID },
                new UserEntity { Name = "admin4", Password = "4", EMail = "casp4@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "销售部").ID },
                new UserEntity { Name = "admin5", Password = "5", EMail = "casp5@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "技术部").ID },
                new UserEntity { Name = "admin6", Password = "6", EMail = "casp6@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "总公司").ID },
                new UserEntity { Name = "admin7", Password = "7", EMail = "casp7@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "技术部").ID },
                new UserEntity { Name = "admin8", Password = "8", EMail = "casp8@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "技术部").ID },
                new UserEntity { Name = "admin9", Password = "9", EMail = "casp9@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "销售部").ID }
            };
            sysusers.ForEach(s => context.Users.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //角色表初始化
            var sysroles = new List<RoleEntity>
            {
                new RoleEntity{Name="admin",Desc="admin"},
                new RoleEntity{Name="user",Desc="User"}
            };
            sysroles.ForEach(r => context.Roles.AddOrUpdate(c => c.Name, r));
            context.SaveChanges();

            //用户角色表初始化，建立用户和角色多对多关系
            var userroles = new List<UserRoleEntity>
            {
                new UserRoleEntity{
                    UserID=sysusers.Single(u => u.Name == "admin1").ID,
                    RoleID=sysroles.Single(r => r.Name == "user").ID
                },
                new UserRoleEntity{
                    UserID=sysusers.Single(u => u.Name == "admin1").ID,
                    RoleID=sysroles.Single(r => r.Name == "admin").ID
                },
                new UserRoleEntity{
                    UserID=sysusers.Single(u => u.Name == "admin2").ID,
                    RoleID=sysroles.Single(r => r.Name == "user").ID
                },
                new UserRoleEntity{
                    UserID=sysusers.Single(u => u.Name == "admin3").ID,
                    RoleID=sysroles.Single(r => r.Name == "user").ID
                }
            };

            foreach (UserRoleEntity tUserRole in userroles)
            {
                //查重
                var db = context.UserRoles.Where(t =>
                t.User.ID == tUserRole.UserID &
                t.Role.ID == tUserRole.RoleID).SingleOrDefault();
                if (db == null)
                {
                    context.UserRoles.Add(tUserRole);
                }
            }
            context.SaveChanges();

            //权限表初始化
            var syspremissions = new List<PremissionEntity>
            {
                new PremissionEntity{ Name="新建", Desc = "新建"},
                new PremissionEntity{ Name="编辑", Desc = "编辑"},
                new PremissionEntity{ Name="删除", Desc = "删除"},
                new PremissionEntity{ Name="打印", Desc = "打印"},
                new PremissionEntity{ Name="导入", Desc = "导入"},
                new PremissionEntity{ Name="导出", Desc = "导出"},
                new PremissionEntity{ Name="分配", Desc = "分配"}
            };
            syspremissions.ForEach(s => context.Premissions.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //模块表初始化
            var sysmodule = new List<ModuleEntity>
            {
                new ModuleEntity{Name = "系统管理", Desc = "系统管理", ParentID = 0}
            };
            sysmodule.ForEach(s => context.Modules.AddOrUpdate(m => m.Name, s));
            context.SaveChanges();

            var sysmodulechild = new List<ModuleEntity>
            {
                new ModuleEntity{Name = "用户管理", Desc = "系统管理", ParentID = context.Modules.Single(mo => mo.Name == "系统管理").ID},
                new ModuleEntity{Name = "角色管理", Desc = "系统管理", ParentID = context.Modules.Single(mo => mo.Name == "系统管理").ID},
                new ModuleEntity{Name = "权限管理", Desc = "系统管理", ParentID = context.Modules.Single(mo => mo.Name == "系统管理").ID}
            };
            sysmodulechild.ForEach(s => context.Modules.AddOrUpdate(m => m.Name, s));
            context.SaveChanges();

            var sysmodulepremission = new List<ModulePremissionEntity>
            {
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "用户管理").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "新建").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "用户管理").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "编辑").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "用户管理").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "删除").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "用户管理").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "打印").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "用户管理").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "导入").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "用户管理").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "导出").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "用户管理").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "分配").ID
                }
            };

            foreach (ModulePremissionEntity mp in sysmodulepremission)
            {
                var db = context.ModulePremissions.Where(
                    b => b.Module.ID == mp.ModuleID &
                    b.Premission.ID == mp.PremissionID).SingleOrDefault();
                if (db == null)
                {
                    context.ModulePremissions.Add(mp);
                }
            };
            context.SaveChanges();

            var sysrolemodulepremission = new List<RoleModulePremissionEntity>
            {
                new RoleModulePremissionEntity
                {
                    RoleID = context.Roles.Single(r => r.Name=="user").ID,

                    ModulePremissionID = context.ModulePremissions.Single(
                        mp => mp.ModuleID == context.Modules.FirstOrDefault(m => m.Name =="用户管理").ID  &
                        mp.PremissionID == context.Premissions.FirstOrDefault(p => p.Name == "新建").ID).ID
                },
                new RoleModulePremissionEntity
                {
                    RoleID = context.Roles.Single(r => r.Name=="user").ID,

                    ModulePremissionID = context.ModulePremissions.Single(
                        mp => mp.ModuleID == context.Modules.FirstOrDefault(m => m.Name =="用户管理").ID  &
                        mp.PremissionID == context.Premissions.FirstOrDefault(p => p.Name == "打印").ID).ID
                }
            };

            foreach (RoleModulePremissionEntity rmp in sysrolemodulepremission)
            {
                var db = context.RoleModulePremissions.Where(
                    b => b.Role.ID == rmp.RoleID &
                    b.ModulePremission.ID == rmp.ModulePremissionID).SingleOrDefault();
                if (db == null)
                {
                    context.RoleModulePremissions.Add(rmp);
                }
            };
            context.SaveChanges();
        }
    }
}