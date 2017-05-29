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
    public class RoleOptionsController : Controller
    {
        private IluminaContext db = new IluminaContext();

        // GET: RoleOptions
        public ActionResult Index()
        {
            var roleOptions = db.RoleOption.Include(r => r.option).Include(r => r.role);
            return View(roleOptions.ToList());
        }

        // GET: RoleOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleOption roleOption = db.RoleOption.Find(id);
            if (roleOption == null)
            {
                return HttpNotFound();
            }
            return View(roleOption);
        }

        // GET: RoleOptions/Create
        public ActionResult Create()
        {
            ViewBag.optionID = new SelectList(db.Options, "optionID", "name");
            ViewBag.roleID = new SelectList(db.Role, "roleID", "name");
            return View();
        }

        // POST: RoleOptions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "roleOptionID,roleID,optionID")] RoleOption roleOption)
        {
            if (ModelState.IsValid)
            {
                db.RoleOption.Add(roleOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.optionID = new SelectList(db.Options, "optionID", "name", roleOption.optionID);
            ViewBag.roleID = new SelectList(db.Role, "roleID", "name", roleOption.roleID);
            return View(roleOption);
        }

        // GET: RoleOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleOption roleOption = db.RoleOption.Find(id);
            if (roleOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.optionID = new SelectList(db.Options, "optionID", "name", roleOption.optionID);
            ViewBag.roleID = new SelectList(db.Role, "roleID", "name", roleOption.roleID);
            return View(roleOption);
        }

        // POST: RoleOptions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roleOptionID,roleID,optionID")] RoleOption roleOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.optionID = new SelectList(db.Options, "optionID", "name", roleOption.optionID);
            ViewBag.roleID = new SelectList(db.Role, "roleID", "name", roleOption.roleID);
            return View(roleOption);
        }

        // GET: RoleOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleOption roleOption = db.RoleOption.Find(id);
            if (roleOption == null)
            {
                return HttpNotFound();
            }
            return View(roleOption);
        }

        // POST: RoleOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleOption roleOption = db.RoleOption.Find(id);
            db.RoleOption.Remove(roleOption);
            db.SaveChanges();
            return RedirectToAction("Index");
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
