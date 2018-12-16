using MVCDemo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCDemo.DAL
{
    public class BaseContext : DbContext
    {

        /// <summary>
        /// 构造函数中的 base("AccountContext") 。
        /// 默认情况下和类名一样，即AccountContext，我们显式的给他指定出来。
        /// </summary>
        public BaseContext() : base("BaseContext")
        {

        }

        //public DbSet<Students> Students { get; set; }

        //public DbSet<Courses> Courses { get; set; }

        //public DbSet<StudentCousers> StuCousers { get; set; }
        
        public DbSet<TUsers> TUsers { get; set; }

        public DbSet<TRoles> TRoles { get; set; }

        public DbSet<TUserRoles> TUserRoles { get; set; }
        /// <summary>
        /// 指定单数形式的表名
        /// 默认情况下会生成复数形式的表，如Users
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }  
}