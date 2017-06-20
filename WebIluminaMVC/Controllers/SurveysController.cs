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
using WebIluminaMVC.ModelView;

namespace WebIluminaMVC.Controllers
{
    public class SurveysController : Controller
    {
        private IluminaContext db = new IluminaContext();

        // GET: Surveys
        public ActionResult Index()
        {
            return View(db.Survey.ToList());
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            SurveyView objSurveyView = new SurveyView();

            objSurveyView.survey = new Survey();
            objSurveyView.surveyDetail = new SurveyDetail();

            return View(objSurveyView);
        }

        // POST: Surveys/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyView surveyView)
        {
            if (surveyView.survey.surveyID != 0)
            {

                surveyView.survey.dateFrom = DateTime.ParseExact(Request.Form["CtrlDateFrom"], "dd/MM/yyyy", null);
                surveyView.survey.dateTo = DateTime.ParseExact(Request.Form["CtrlDateTo"], "dd/MM/yyyy", null);

                db.Entry(surveyView.survey).State = EntityState.Modified;
                db.SaveChanges();

                if (surveyView.surveyDetail.surveyDetailID != 0)
                {
                    db.Entry(surveyView.surveyDetail).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    surveyView.surveyDetail.surveyID = surveyView.survey.surveyID;
                    surveyView.surveyDetail.active = true;
                    db.SurveyDetail.Add(surveyView.surveyDetail);
                    db.SaveChanges();
                }
            }
            else
            {
                surveyView.survey.dateFrom = DateTime.ParseExact(Request.Form["CtrlDateFrom"], "dd/MM/yyyy", null);
                surveyView.survey.dateTo = DateTime.ParseExact(Request.Form["CtrlDateTo"], "dd/MM/yyyy", null);
                db.Survey.Add(surveyView.survey);
                db.SaveChanges();
            }

            surveyView.surveyDetailList = db.SurveyDetail.Where(u=>u.surveyID==surveyView.survey.surveyID).ToList();

            return View(surveyView);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "surveyID,name,dateFrom,dateTo,active,createDate,createUser,updateDate,updateUser")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Survey.Find(id);
            db.Survey.Remove(survey);
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
