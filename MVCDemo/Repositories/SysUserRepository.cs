using MVCDemo.Areas.Admin.Models;
using MVCDemo.DAL;
using MVCDemo.Repositories;
using System.Linq;

public class SysUserRepository : ISysUserRepository
{
    protected BaseContext db = new BaseContext();

    //查询所有用户
    public IQueryable<TUser> SelectAll()
    {
        return db.TUsers;
    }

    //通过用户名查询用户
    public TUser SelectByName(string userName)
    {
        return db.TUsers.FirstOrDefault(u => u.Name == userName);
    }

    //添加用户
    public void Add(TUser tUser)
    {
        db.TUsers.Add(tUser);
        db.SaveChanges();
    }

    //删除用户
    public bool Delete(int id)
    {
        var delSysUser = db.TUsers.FirstOrDefault(u => u.ID == id);

        if (delSysUser != null)
        {
            db.TUsers.Remove(delSysUser);
            db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}