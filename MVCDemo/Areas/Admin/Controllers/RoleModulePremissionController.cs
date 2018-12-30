using MVCDemo.Areas.Admin.ViewModels;
using MVCDemo.DAL;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class RoleModulePremissionController : Controller
    {
        private BaseContext db = new BaseContext();
        // GET: Admin/RoleModulePremission
        public ActionResult Index()
        {
            var viewModel = new RoleModulePremissionIndexData()
            {
                VMRoles = db.Roles.Include(c => c.RoleModulePremissions.Select(rmp =>rmp.ModulePremission)).OrderBy(c=>c.ID)
            };
            //viewModel.VMModulePremissions = viewModel.VMRoles.
            return View(viewModel);
        }
    }
}