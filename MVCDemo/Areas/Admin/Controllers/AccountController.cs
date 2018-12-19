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
        private string OrderColumn = "";
        // GET: Account

        #region List
        public ActionResult Index(string SortOrder)
        {
            //OrderColumn = string.IsNullOrEmpty(SortOrder) ? "EMail": "";
            if(string.IsNullOrEmpty(SortOrder))
            {
                OrderColumn = "ID";
            }
            else if (SortOrder == OrderColumn)
            {
                OrderColumn = SortOrder.EndsWith("_D") ? SortOrder.Substring(0, SortOrder.Length - 2) : SortOrder + "_D";
            }
            else
            {
                OrderColumn = SortOrder;
            }
            var users = from u in db.TUsers select u;

            switch(OrderColumn)
            {
                case "ID":
                    users = users.OrderBy(u => u.ID);
                    break;
                case "ID_D":
                    users = users.OrderByDescending(u => u.ID);
                    break;
                case "Name":
                    users = users.OrderBy(u => u.Name);
                    break;
                case "Name_D":
                    users = users.OrderByDescending(u => u.Name);
                    break;
                case "Password":
                    users = users.OrderBy(u => u.Password);
                    break;
                case "Password_D":
                    users = users.OrderByDescending(u => u.Password);
                    break;
                case "EMail":
                    users = users.OrderBy(u => u.EMail);
                    break;
                case "EMail_D":
                    users = users.OrderByDescending(u => u.EMail);
                    break;
                default:
                    users = users.OrderByDescending(u => u.ID); 
                    break;
            }

            return View(users.ToList());
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

        #region Details
        public ActionResult Details (int id)
        {
            var user = db.TUsers.Find(id);
            return View(user);
        }
        #endregion
    }
}