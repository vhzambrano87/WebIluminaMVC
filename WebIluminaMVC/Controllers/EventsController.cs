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
            return View(db.Event.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
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

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventID,title,date,place,imageUrl,active,createDate,createUser,updateDate,updateUser")] Event @event)
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

                        @event.imageUrl = fileName;
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

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Events/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event @event)
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
                            System.IO.File.Delete(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageEvent"] + @event.eventID + @event.imageUrl));
                        }
                        var path = Path.Combine(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageEvennt"] + @event.eventID), fileName);
                        file.SaveAs(path);
                        @event.imageUrl = fileName;
                    }
                }

                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Event.Find(id);
            db.Event.Remove(@event);
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
