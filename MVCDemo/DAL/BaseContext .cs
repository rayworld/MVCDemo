using MVCDemo.Areas.Admin.Models;
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
        public BaseContext() : base("baseContext") { }
        
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<UserRoleEntity>  UserRoles { get; set; }

        public DbSet<DeptEntity> Depts { get; set; }

        public DbSet<RoleModulePremissionEntity> RoleModulePremissions { get; set; }

        public DbSet<PremissionEntity> Premissions { get; set; }

        public DbSet<ModuleEntity> Modules { get; set; }

        public DbSet<ModulePremissionEntity> ModulePremissions { get; set; }
        
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