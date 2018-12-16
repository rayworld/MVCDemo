using MVCDemo.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCDemo.DAL
{
    public class BaseInitializer : DropCreateDatabaseIfModelChanges<BaseContext>
    {
        protected override void Seed(BaseContext context)
        {
            var sysuser = new List<TUsers>
            {
                new TUsers{Name="ssdfsdf",Password="32123"},
                new TUsers{Name="sdfw",Password="1234"},
                new TUsers{Name="eeff",Password="123"}
            };
            sysuser.ForEach(u => context.TUsers.Add(u));

            var sysrole = new List<TRoles>
            {
                new TRoles{Name="admin",Desc="admin"},
                new TRoles{Name="user",Desc="User"}
            };
            sysrole.ForEach(r => context.TRoles.Add(r));

            context.SaveChanges();
            //var student = new List<Students>
            //{
            //new Students{Name="小明",Password="123456",Sex="男", Age= 50},
            //new Students{Name="小芳",Password="654321",Sex="女", Age= 48}
            //};

            //student.ForEach(s => context.Students.Add(s));
            ////context.SaveChanges();

            //var course = new List<Courses>
            //{
            //new Courses{Name="语文",Code="10001"},
            //new Courses{Name="数学",Code="10002"}
            //};

            //course.ForEach(c => context.Courses.Add(c));

            //var sysuser = new List<Users>
            //{
            //    new Users{Name="ssdfsdf",Password="32123"},
            //    new Users{Name="sdfw",Password="1234"},
            //    new Users{Name="eeff",Password="123"}
            //};
            //sysuser.ForEach(u => context.SysUser.Add(u));
            //context.SaveChanges();
        }
    }    
}