using MVCDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class RoleController : Controller
    {

        private BaseContext db = mew BaseContext();
        // GET: Role
        public ActionResult Index()
        {
            return View(db.TRoles.ToList());
        }
    }
}