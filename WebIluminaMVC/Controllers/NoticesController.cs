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
            if(DataUtil.Validation())
                return View(db.Notice.ToList());
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Notices/Details/5
        public ActionResult Details(int? id)
        {
            if (DataUtil.Validation())
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
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Notices/Create
        public ActionResult Create()
        {
            if(DataUtil.Validation())
                return View();
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Notices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "noticeID,title,publishDate,author,contents,imageUrl,active,createDate,createUser,updateDate,updateUser")] Notice notice)
        {
            if (DataUtil.Validation())
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
                                                    
                            
                            notice.imageUrl = System.Configuration.ConfigurationManager.AppSettings["URLImageNotice"] + notice.noticeID + "/" + fileName; 
                            db.Notice.Add(notice);
                            db.SaveChanges();

                            Directory.CreateDirectory(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID));
                            var path = Path.Combine(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID), fileName);

                            file.SaveAs(path);
                        }
                    }


                    return RedirectToAction("Index");
                }

                return View(notice);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Notices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (DataUtil.Validation())
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
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Notice notice)
        {
            if (DataUtil.Validation())
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
                                System.IO.File.Delete(notice.imageUrl);
                            }

                            notice.imageUrl = System.Configuration.ConfigurationManager.AppSettings["URLImageNotice"] + notice.noticeID + "/" + fileName;

                            var path = Path.Combine(Server.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RouteImageNotice"] + notice.noticeID), fileName);
                            
                            
                            file.SaveAs(path);

                            
                        }
                    }

                    db.Entry(notice).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return View(notice);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Notices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (DataUtil.Validation())
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
            else
                return RedirectToAction("Login", "Home");
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (DataUtil.Validation())
            {
                Notice notice = db.Notice.Find(id);
                db.Notice.Remove(notice);
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
