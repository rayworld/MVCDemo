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

            //���ű��ʼ��
            // ������Ҫ�����ӵı�ֻ��һ�����ļ��룬��Ҫ�õ��ϼ���ID
            var sysdepts = new List<DeptEntity>
            {
                new DeptEntity{Name = "�ܹ�˾", Desc = "�ܹ�˾", SortOrder = 0, ParantID = 0 }
            };
            sysdepts.ForEach(d => context.Depts.AddOrUpdate(p => p.Name, d));
            context.SaveChanges();

            //�ڶ���
            var sysdepts1 = new List<DeptEntity>
            {
                new DeptEntity{Name = "�г���", Desc = "�г���", SortOrder = 1, ParantID = context.Depts.Single(e => e.Name == "�ܹ�˾").ID },
                new DeptEntity{Name = "������", Desc = "������", SortOrder = 2, ParantID = context.Depts.Single(e => e.Name == "�ܹ�˾").ID },
                new DeptEntity{Name = "���۲�", Desc = "���۲�", SortOrder = 3, ParantID = context.Depts.Single(e => e.Name == "�ܹ�˾").ID },
                new DeptEntity{Name = "����", Desc = "����", SortOrder = 4, ParantID = context.Depts.Single(e => e.Name == "�ܹ�˾").ID }
            };
            sysdepts1.ForEach(d => context.Depts.AddOrUpdate(p => p.Name, d));
            context.SaveChanges();

            //�û����ʼ��
            var sysusers = new List<UserEntity>
            {
                new UserEntity { Name = "admin1", Password = "1", EMail = "casp1@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "������").ID },
                new UserEntity { Name = "admin2", Password = "2", EMail = "casp2@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "�ܹ�˾").ID },
                new UserEntity { Name = "admin3", Password = "3", EMail = "casp3@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "����").ID },
                new UserEntity { Name = "admin4", Password = "4", EMail = "casp4@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "���۲�").ID },
                new UserEntity { Name = "admin5", Password = "5", EMail = "casp5@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "������").ID },
                new UserEntity { Name = "admin6", Password = "6", EMail = "casp6@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "�ܹ�˾").ID },
                new UserEntity { Name = "admin7", Password = "7", EMail = "casp7@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "������").ID },
                new UserEntity { Name = "admin8", Password = "8", EMail = "casp8@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "������").ID },
                new UserEntity { Name = "admin9", Password = "9", EMail = "casp9@sina.com", CreateDate = System.DateTime.Now, DeptID = context.Depts.Single(d => d.Name == "���۲�").ID }
            };
            sysusers.ForEach(s => context.Users.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //��ɫ���ʼ��
            var sysroles = new List<RoleEntity>
            {
                new RoleEntity{Name="admin",Desc="admin"},
                new RoleEntity{Name="user",Desc="User"}
            };
            sysroles.ForEach(r => context.Roles.AddOrUpdate(c => c.Name, r));
            context.SaveChanges();

            //�û���ɫ���ʼ���������û��ͽ�ɫ��Զ��ϵ
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
                //����
                var db = context.UserRoles.Where(t =>
                t.User.ID == tUserRole.UserID &
                t.Role.ID == tUserRole.RoleID).SingleOrDefault();
                if (db == null)
                {
                    context.UserRoles.Add(tUserRole);
                }
            }
            context.SaveChanges();

            //Ȩ�ޱ��ʼ��
            var syspremissions = new List<PremissionEntity>
            {
                new PremissionEntity{ Name="�½�", Desc = "�½�"},
                new PremissionEntity{ Name="�༭", Desc = "�༭"},
                new PremissionEntity{ Name="ɾ��", Desc = "ɾ��"},
                new PremissionEntity{ Name="��ӡ", Desc = "��ӡ"},
                new PremissionEntity{ Name="����", Desc = "����"},
                new PremissionEntity{ Name="����", Desc = "����"},
                new PremissionEntity{ Name="����", Desc = "����"}
            };
            syspremissions.ForEach(s => context.Premissions.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            //ģ����ʼ��
            var sysmodule = new List<ModuleEntity>
            {
                new ModuleEntity{Name = "ϵͳ����", Desc = "ϵͳ����", ParentID = 0}
            };
            sysmodule.ForEach(s => context.Modules.AddOrUpdate(m => m.Name, s));
            context.SaveChanges();

            var sysmodulechild = new List<ModuleEntity>
            {
                new ModuleEntity{Name = "�û�����", Desc = "ϵͳ����", ParentID = context.Modules.Single(mo => mo.Name == "ϵͳ����").ID},
                new ModuleEntity{Name = "��ɫ����", Desc = "ϵͳ����", ParentID = context.Modules.Single(mo => mo.Name == "ϵͳ����").ID},
                new ModuleEntity{Name = "Ȩ�޹���", Desc = "ϵͳ����", ParentID = context.Modules.Single(mo => mo.Name == "ϵͳ����").ID}
            };
            sysmodulechild.ForEach(s => context.Modules.AddOrUpdate(m => m.Name, s));
            context.SaveChanges();

            var sysmodulepremission = new List<ModulePremissionEntity>
            {
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "�û�����").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "�½�").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "�û�����").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "�༭").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "�û�����").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "ɾ��").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "�û�����").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "��ӡ").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "�û�����").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "����").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "�û�����").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "����").ID
                },
                new ModulePremissionEntity
                {
                    ModuleID = context.Modules.Single(m => m.Name == "�û�����").ID,
                    PremissionID = context.Premissions.Single(m => m.Name == "����").ID
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
                        mp => mp.ModuleID == context.Modules.FirstOrDefault(m => m.Name =="�û�����").ID  &
                        mp.PremissionID == context.Premissions.FirstOrDefault(p => p.Name == "�½�").ID).ID
                },
                new RoleModulePremissionEntity
                {
                    RoleID = context.Roles.Single(r => r.Name=="user").ID,

                    ModulePremissionID = context.ModulePremissions.Single(
                        mp => mp.ModuleID == context.Modules.FirstOrDefault(m => m.Name =="�û�����").ID  &
                        mp.PremissionID == context.Premissions.FirstOrDefault(p => p.Name == "��ӡ").ID).ID
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