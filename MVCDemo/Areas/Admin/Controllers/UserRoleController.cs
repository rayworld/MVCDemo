using MVCDemo.Areas.Admin.ViewModels;
using MVCDemo.DAL;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class UserRoleController : Controller
    {
        private BaseContext db = new BaseContext();

        //
        // GET: /UserRole/
        public ActionResult Index(int? id)
        {
            var viewModel = new UserRoleIndexData
            {
                VMUsers = db.Users.Include(u => u.Dept).Include(u => u.UserRoles.Select(ur => ur.Role)).OrderBy(u => u.Name)
            };

            if (id != null)
            {
                ViewBag.UserID = id.Value;
                viewModel.VMUserRoles = viewModel.VMUsers.Where(u => u.ID == id.Value).Single().UserRoles;
                viewModel.VMRoles = (viewModel.VMUserRoles.Where(
                ur => ur.UserID == id.Value)).Select(ur => ur.Role);
            }
            return View(viewModel);

        }
    }
}