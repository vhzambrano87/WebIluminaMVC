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
    public class NoticesController : Controller
    {
        private IluminaContext db = new IluminaContext();

        // GET: Notices
        public ActionResult Index()
        {
            return View(db.Notice.ToList());
        }

        // GET: Notices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notice.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // GET: Notices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "noticeID,title,publishDate,author,contents,imageUrl,active,createDate,createUser,updateDate,updateUser")] Notice notice)
        {            
            if (ModelState.IsValid)
            {
                notice.publishDate = DateTime.ParseExact(Request.Form["CtrlPublishDate"], "dd/MM/yyyy", null);
                

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        notice.imageUrl = fileName;
                        db.Notice.Add(notice);
                        db.SaveChanges();                        

                        Directory.CreateDirectory(Server.MapPath("~"+System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID));
                        var path = Path.Combine(Server.MapPath("~"+System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID), fileName);                        
                        file.SaveAs(path);
                    }
                }


                return RedirectToAction("Index");
            }

            return View(notice);
        }

        // GET: Notices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notice.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Notice notice)
        {
            if (ModelState.IsValid)
            {               
            
                notice.publishDate = DateTime.ParseExact(Request.Form["CtrlPublishDate"], "dd/MM/yyyy", null);

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);                        

                        if (!Directory.Exists(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID)))
                        {
                            Directory.CreateDirectory(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID));
                        }
                        else
                        {
                            System.IO.File.Delete(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID + notice.imageUrl));
                        }
                        var path = Path.Combine(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID), fileName);
                        file.SaveAs(path);
                        notice.imageUrl = fileName;
                    }
                }

                db.Entry(notice).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(notice);
        }

        // GET: Notices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notice.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notice notice = db.Notice.Find(id);
            db.Notice.Remove(notice);
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
