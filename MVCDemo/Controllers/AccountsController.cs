using MVCDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class AccountsController : Controller
    {
        private BaseContext db = new BaseContext();
        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.TUsers.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail3"].ToString();
            string password = fc["inputPassword3"].ToString();
            var user = db.TUsers.Where(u => u.EMail == email & u.Password == password);
            if (user.Count() > 0)
            {
                RedirectToAction("Role", "Index");
            }
            else
            {
                RedirectToAction("Acounts", "Login");
            }
            return View();
        }
    }
}