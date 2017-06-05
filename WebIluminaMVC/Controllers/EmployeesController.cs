using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebIluminaMVC.DataAccess;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private IluminaContext db = new IluminaContext();        

        // GET: Employees
        public ActionResult Index()
        {
            if (DataUtil.Validation())
                return View(db.Employee.ToList());
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employee.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            else
                return RedirectToAction("Login", "Home");            
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            if(DataUtil.Validation())
                return View();
            else
                return RedirectToAction("Login", "Home");            
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeID,name,lastname_first,lastname_second,mobilephone,area,email,active,createDate,createUser,updateDate,updateUser")] Employee employee)
        {
            if (DataUtil.Validation())
            {
                if (ModelState.IsValid)
                {
                    db.Employee.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(employee);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employee.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeID,name,lastname_first,lastname_second,mobilephone,area,email,active,createDate,createUser,updateDate,updateUser")] Employee employee)
        {
            if (DataUtil.Validation())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employee.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (DataUtil.Validation())
            {
                Employee employee = db.Employee.Find(id);
                db.Employee.Remove(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Login", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
