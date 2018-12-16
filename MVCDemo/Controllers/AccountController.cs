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
            return View(db.TUsers.ToList());
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
            var user11 = db.TUsers.Where(u => u.EMail == email);
            ViewBag.State = user11.Count();

            return View();
        }
    }
}