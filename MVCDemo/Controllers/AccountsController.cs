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
    }
}