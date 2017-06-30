using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebIluminaMVC.DataAccess;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.Controllers
{
    public class EventsController : Controller
    {
        private IluminaContext db = new IluminaContext();

        // GET: Events
        public ActionResult Index()
        {
            if(DataUtil.Validation())
                return View(db.Event.ToList());
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Event @event = db.Event.Find(id);
                if (@event == null)
                {
                    return HttpNotFound();
                }
                return View(@event);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            Model.Event objEvent = new Model.Event();
            return View(objEvent);
        }

        // POST: Events/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventID,title,date,place,imageUrl,active,createDate,createUser,updateDate,updateUser")] Event @event)
        {
            if (DataUtil.Validation())
            {
                if (ModelState.IsValid)
                {
                    @event.date = DateTime.ParseExact(Request.Form["CtrlDate"] + @event.date + Request.Form["CtrlTime"], "dd/MM/yyyy HH:mm", null);

                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);

                            @event.imageUrl = System.Configuration.ConfigurationManager.AppSettings["URLImageEvent"] + @event.eventID + "/" + fileName; ;
                            db.Event.Add(@event);
                            db.SaveChanges();

                            Directory.CreateDirectory(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageEvent"] + @event.eventID));
                            var path = Path.Combine(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageEvent"] + @event.eventID), fileName);
                            file.SaveAs(path);
                        }
                    }

                    return RedirectToAction("Index");
                }

                return View(@event);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Event @event = db.Event.Find(id);
                if (@event == null)
                {
                    return HttpNotFound();
                }
                return View(@event);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Events/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event @event)
        {
            if (DataUtil.Validation())
            {
                if (ModelState.IsValid)
                {
                    @event.date = DateTime.ParseExact(Request.Form["CtrlDate"], "dd/MM/yyyy", null);

                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);

                            if (!Directory.Exists(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageEvent"] + @event.eventID)))
                            {
                                Directory.CreateDirectory(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageEvent"] + @event.eventID));
                            }
                            else
                            {
                                System.IO.File.Delete(@event.imageUrl);
                            }
                            
                            @event.imageUrl = System.Configuration.ConfigurationManager.AppSettings["URLImageEvent"] + @event.eventID + "/" + fileName;

                            var path = Path.Combine(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageEvent"] + @event.eventID), fileName);
                            file.SaveAs(path);
                        }
                    }

                    db.Entry(@event).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return View(@event);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Event @event = db.Event.Find(id);
                if (@event == null)
                {
                    return HttpNotFound();
                }
                return View(@event);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (DataUtil.Validation())
            {
                Event @event = db.Event.Find(id);
                db.Event.Remove(@event);
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
