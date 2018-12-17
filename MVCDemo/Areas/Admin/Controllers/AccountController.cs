using MVCDemo.Areas.Admin.Models;
using MVCDemo.DAL;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private BaseContext db = new BaseContext();
        // GET: Account

        #region List
        public ActionResult Index()
        {
            return View(db.TUsers.ToList());
        }
        #endregion

        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];
            var user11 = db.TUsers.Where(u => u.EMail == email & u.Password == password);
            if (user11.Count() > 0)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region Insert

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TUser sysUser)
        {
            db.TUsers.Add(sysUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            TUser tUser = db.TUsers.Find(id);
            return View(tUser);
        }

        [HttpPost]
        public ActionResult Edit(TUser tUser)
        {
            db.Entry(tUser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public ActionResult Delete(int id)
        {
            TUser tUser = db.TUsers.Find(id);
            return View(tUser);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TUser sysUser = db.TUsers.Find(id);
            db.TUsers.Remove(sysUser);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        #endregion
    }
}