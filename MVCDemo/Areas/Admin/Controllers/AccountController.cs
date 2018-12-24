using MVCDemo.Areas.Admin.Models;
using MVCDemo.DAL;
using PagedList;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Account

        #region List
        public ActionResult Index(string SortOrder,string QueryString1, int? PageIndex)
        {
            ViewBag.CurrSortOrder = string.IsNullOrEmpty(SortOrder) ? "ID" : SortOrder;
            //ViewBag.CurrPageIndex = PageIndex;
            if (!string.IsNullOrEmpty(QueryString1))
            {
                PageIndex = 1;
                //ViewBag.CurrPageIndex = PageIndex;
            }
            else
            {
                ViewBag.CurrQueryString = QueryString1;
            }

            //var users = from u in db.TUsers select u;
            var users = db.TUsers.Include(u => u.TDept);


            if(!string.IsNullOrEmpty(QueryString1))
            {
                users = users.Where(u => u.Name.Contains(QueryString1) || 
                u.EMail.Contains(QueryString1));
            }

            switch(ViewBag.CurrSortOrder)
            {
                case "ID":
                    users = users.OrderBy(u => u.ID);
                    break;
                case "ID_D":
                    users = users.OrderByDescending(u => u.ID);
                    break;
                case "Name":
                    users = users.OrderBy(u => u.Name);
                    break;
                case "Name_D":
                    users = users.OrderByDescending(u => u.Name);
                    break;
                case "Password":
                    users = users.OrderBy(u => u.Password);
                    break;
                case "Password_D":
                    users = users.OrderByDescending(u => u.Password);
                    break;
                case "EMail":
                    users = users.OrderBy(u => u.EMail);
                    break;
                case "EMail_D":
                    users = users.OrderByDescending(u => u.EMail);
                    break;
                case "CreateDate":
                    users = users.OrderBy(u => u.CreateDate);
                    break;
                case "CreateDate_D":
                    users = users.OrderByDescending(u => u.CreateDate);
                    break;
                case "DeptName":
                    users = users.OrderBy(u => u.TDept.Name);
                    break;
                case "DeptName_D":
                    users = users.OrderByDescending(u => u.TDept.Name);
                    break;
                default:
                    users = users.OrderByDescending(u => u.ID); 
                    break;
            }

            //return View(users.ToList());
            int pageSize = 3;
            int pageNumber = (PageIndex ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];
            var user11 = db.TUsers.Where(u => u.EMail == email & u.Password == password);
            if (user11.Count() > 0)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region Insert

        public ActionResult Create()
        {
            List<SelectListItem> TDeptList = new List<SelectListItem>();

            var tDepts = db.TDepts.Where(u => u.ID > 0);
            foreach (TDept dept in tDepts)
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = dept.ID.ToString(),
                    Text = dept.Name.ToString()
                };
                TDeptList.Add(item);
            };
            SelectList TDeptID = new SelectList(TDeptList, "Value", "Text");
            ViewBag.TDeptID = TDeptID;
            return View();
        }

        [HttpPost]
        public ActionResult Create(TUser sysUser)
        {
            if (ModelState.IsValid)
            {
                db.TUsers.Add(sysUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            TUser tUser = db.TUsers.Find(id);
            return View(tUser);
        }

        [HttpPost]
        public ActionResult Edit(TUser tUser)
        {
            db.Entry(tUser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public ActionResult Delete(int id)
        {
            TUser tUser = db.TUsers.Find(id);
            return View(tUser);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TUser sysUser = db.TUsers.Find(id);
            db.TUsers.Remove(sysUser);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        #endregion

        #region Details
        public ActionResult Details (int id)
        {
            var user = db.TUsers.Find(id);
            return View(user);
        }
        #endregion
    }
}