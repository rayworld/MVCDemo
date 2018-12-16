using MVCDemo.DAL;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class AccountController : Controller
    {
        private BaseContext db = new BaseContext();
        // GET: Account
        public ActionResult Index()
        {
            return View(db.TUser.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];
            var user11 = db.TUser.Where(u => u.EMail == email & u.Password == password);
            //ViewBag.State = user11.Count();
            if (user11.Count() > 0)
            {
                //return View("Index",db.TUser.ToList());
                return RedirectToAction("Index", "Account");
                //return null;
            }
            else
            {
                return View();
            }
        }
    }
}