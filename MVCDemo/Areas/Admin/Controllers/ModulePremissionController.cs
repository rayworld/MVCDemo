using MVCDemo.Areas.Admin.ViewModels;
using MVCDemo.DAL;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class ModulePremissionController : Controller
    {
        private BaseContext db = new BaseContext();
        // GET: Admin/ModulePremission
        public ActionResult Index()
        {
            var viewModel = new ModulePremissionIndexData()
            {
                VMModules = db.Modules.Include(m => m.ModulePremissions.Select(mp => mp.Premission)).OrderBy(m => m.ID)
            };
            return View(viewModel);
        }
    }
}