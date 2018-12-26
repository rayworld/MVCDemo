using MVCDemo.DAL;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private BaseContext db = new BaseContext();
        // GET: Role
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }
    }
}