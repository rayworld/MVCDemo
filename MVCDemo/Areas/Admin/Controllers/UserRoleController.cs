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
                TUsers = db.TUsers.Include(u => u.TDept).Include(u => u.TUserRoles.Select(ur => ur.TRole)).OrderBy(u => u.Name)
            };

            if (id != null)
            {
                ViewBag.UserID = id.Value;
                viewModel.TUserRoles = viewModel.TUsers.Where(u => u.ID == id.Value).Single().TUserRoles;
                viewModel.TRoles = (viewModel.TUserRoles.Where(
                ur => ur.TUserID == id.Value)).Select(ur => ur.TRole);
            }
            return View(viewModel);

        }
    }
}