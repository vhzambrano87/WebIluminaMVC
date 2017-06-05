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
    public class UsersController : Controller
    {
        private IluminaContext db = new IluminaContext();

        // GET: Users
        public ActionResult Index()
        {
            if(DataUtil.Validation())
            return View(db.User.ToList().OrderBy(x=>x.name));
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            if(DataUtil.Validation())
            return View();
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,name,lastname,username,password,active,email,dni,phonenumber,createDate,createUser,updateDate,updateUser")] User user)
        {
            if (DataUtil.Validation())
            {
                if (ModelState.IsValid)
                {
                    var objUser = db.User.FirstOrDefault(u => u.username == user.username);
                    var objUserEmail = db.User.FirstOrDefault(u => u.email == user.email);
                    if (objUser == null && objUserEmail == null)
                    {
                        user.createDate = DateTime.Now;
                        db.User.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (objUser != null)
                            user.messageErrorUser = "El usuario ingresado ya existe!.";

                        if (objUserEmail != null)
                            user.messageErrorEmail = "El email ingresado ya existe!.";

                        return View(user);
                    }
                }
                return View(user);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.User.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,name,lastname,username,password,active,email,dni,phonenumber,createDate,createUser,updateDate,updateUser")] User user)
        {
            if (DataUtil.Validation())
            {
                if (ModelState.IsValid)
                {
                    var objUserEmail = db.User.FirstOrDefault(u => u.email == user.email && u.userID != user.userID);
                    if (objUserEmail != null)
                    {
                        user.messageErrorEmail = "El email ingresado ya existe!.";
                    }
                    else
                    {
                        user.updateDate = DateTime.Now;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.User.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (DataUtil.Validation())
            {
                User user = db.User.Find(id);
                db.User.Remove(user);
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
