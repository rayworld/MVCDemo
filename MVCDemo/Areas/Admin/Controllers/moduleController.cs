using MVCDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class ModuleController : Controller
    {
        private BaseContext db = new BaseContext();
        // GET: Admin/module
        public ActionResult Index()
        {
            return View(db.Modules.ToList());
        }
    }
}