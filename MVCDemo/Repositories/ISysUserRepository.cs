using MVCDemo.Areas.Admin.Models;
using System.Linq;

namespace MVCDemo.Repositories
{
    public interface ISysUserRepository
    {
        //查询所有用户
        IQueryable<TUser> SelectAll();

        //通过用户名查询用户
        TUser SelectByName(string userName);

        //添加用户
        void Add(TUser sysUser);

        //删除用户
        bool Delete(int id);



    }

}
