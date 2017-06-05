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
    public class OptionsController : Controller
    {
        private IluminaContext db = new IluminaContext();

        // GET: Options
        public ActionResult Index()
        {
            if(DataUtil.Validation())
                return View(db.Option.ToList());
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Options/Details/5
        public ActionResult Details(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Option option = db.Option.Find(id);
                if (option == null)
                {
                    return HttpNotFound();
                }
                return View(option);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Options/Create
        public ActionResult Create()
        {
            if(DataUtil.Validation())
            return View();
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Options/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "optionID,name,active,createDate,createUser,updateDate,updateUser,selected")] Option option)
        {
            if (DataUtil.Validation())
            {
                if (ModelState.IsValid)
                {
                    db.Option.Add(option);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(option);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Options/Edit/5
        public ActionResult Edit(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Option option = db.Option.Find(id);
                if (option == null)
                {
                    return HttpNotFound();
                }
                return View(option);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Options/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "optionID,name,active,createDate,createUser,updateDate,updateUser,selected")] Option option)
        {
            if (DataUtil.Validation())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(option).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(option);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Options/Delete/5
        public ActionResult Delete(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Option option = db.Option.Find(id);
                if (option == null)
                {
                    return HttpNotFound();
                }
                return View(option);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Options/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (DataUtil.Validation())
            {
                Option option = db.Option.Find(id);
                db.Option.Remove(option);
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
