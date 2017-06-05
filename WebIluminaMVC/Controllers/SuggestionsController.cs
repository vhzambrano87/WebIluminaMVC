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
    public class SuggestionsController : Controller
    {
        private IluminaContext db = new IluminaContext();

        // GET: Suggestions
        public ActionResult Index()
        {
            if (DataUtil.Validation())
            {
                var suggestion = db.Suggestion.Include(s => s.employee);
                return View(suggestion.ToList());
            }
            else
                return RedirectToAction("Login", "Home");
        }

        // GET: Suggestions/Details/5
        public ActionResult Details(int? id)
        {
            if (DataUtil.Validation())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Suggestion suggestion = db.Suggestion.Find(id);
                if (suggestion == null)
                {
                    return HttpNotFound();
                }
                return View(suggestion);
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
