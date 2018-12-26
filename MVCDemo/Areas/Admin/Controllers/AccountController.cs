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
            var users = db.Users.Include(u => u.Dept);


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
                    //users = users.OrderBy(u => u.SysTitle.Name);
                    break;
                case "DeptName_D":
                    //users = users.OrderByDescending(u => u.SysTitle.Name);
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
            var user11 = db.Users.Where(u => u.EMail == email & u.Password == password);
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
            var Depts1 = from u in db.Depts select u;
            ViewBag.TitleID = BindSelect(Depts1);
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserEntity sysUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(sysUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            UserEntity sysUser = db.Users.Find(id);
            return View(sysUser);
        }

        [HttpPost]
        public ActionResult Edit(UserEntity sysUser)
        {
            db.Entry(sysUser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public ActionResult Delete(int id)
        {
            UserEntity sysUser = db.Users.Find(id);
            return View(sysUser);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserEntity sysUser = db.Users.Find(id);
            db.Users.Remove(sysUser);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        #endregion

        #region Details
        public ActionResult Details (int id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }
        #endregion

        public ActionResult Tree()
        {
            var list = (from a in db.Depts
                        select new {
                            id = a.ID,
                            pid = a.ParantID,
                            name = a.Name,
                            LinkURL = ""
                        }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        private SelectList BindSelect(IQueryable<DeptEntity> Depts1)
        {
            List<SelectListItem> listDepts = new List<SelectListItem>();

            foreach (DeptEntity dept in Depts1)
            {
                SelectListItem itemDept = new SelectListItem()
                {
                    Value = dept.ID.ToString(),
                    Text = dept.Name.ToString()
                };
                listDepts.Add(itemDept);
            };

            SelectList DepartmentID = new SelectList(listDepts, "Value", "Text");
            return DepartmentID;
        }
    }
}