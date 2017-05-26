using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebIluminaMVC.DataAccess;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.REST.Controllers
{
    public class NoticesController : ApiController
    {
        private IluminaContext db = new IluminaContext();

        // GET: api/Notices
        [HttpGet]
        public IQueryable<Notice> GetNotice()
        {
            return db.Notice;
        }

        // GET: api/Notices/5
        [HttpGet]
        public Notice GetNotice(int id)
        {
            Notice notice = db.Notice.Find(id);
            return notice;
        }

        // POST: api/Notices
        [ResponseType(typeof(Notice))]
        public IHttpActionResult PostNotice(Notice notice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notice.Add(notice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notice.noticeID }, notice);
        }

        // DELETE: api/Notices/5
        [ResponseType(typeof(Notice))]
        public IHttpActionResult DeleteNotice(int id)
        {
            Notice notice = db.Notice.Find(id);
            if (notice == null)
            {
                return NotFound();
            }

            db.Notice.Remove(notice);
            db.SaveChanges();

            return Ok(notice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoticeExists(int id)
        {
            return db.Notice.Count(e => e.noticeID == id) > 0;
        }
    }
}