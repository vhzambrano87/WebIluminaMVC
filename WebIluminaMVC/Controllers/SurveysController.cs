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
        
        public ActionResult Index()
        {
            return View(db.Survey.ToList());
        }
        
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
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyView surveyView)
        {           

            if (Request.Form["SurveyID"] != "0" && Request.Form["SurveyID"] != null)
            {
                surveyView.survey.surveyID = Convert.ToInt32(Request.Form["SurveyID"]);
                surveyView.survey.dateFrom = DateTime.ParseExact(Request.Form["CtrlDateFrom"], "dd/MM/yyyy", null);
                surveyView.survey.dateTo = DateTime.ParseExact(Request.Form["CtrlDateTo"], "dd/MM/yyyy", null);

                db.Entry(surveyView.survey).State = EntityState.Modified;
                db.SaveChanges();

                surveyView.surveyDetail.surveyID = surveyView.survey.surveyID;
                surveyView.surveyDetail.name = Request.Form["surveyDetail_name"];
                surveyView.surveyDetail.type = Request.Form["typeDetail"];
                surveyView.surveyDetail.option1 = Request.Form["option1"];
                surveyView.surveyDetail.option2 = Request.Form["option2"];
                surveyView.surveyDetail.option3 = Request.Form["option3"];
                surveyView.surveyDetail.option4 = Request.Form["option4"];
                surveyView.surveyDetail.option5 = Request.Form["option5"];
                surveyView.surveyDetail.option6 = Request.Form["option6"];
                surveyView.surveyDetail.active = true;

                if (Request.Form["HDSurveyDetailID"] == "0" || Request.Form["HDSurveyDetailID"] == "" || Request.Form["HDSurveyDetailID"] == null)
                {                    
                    db.SurveyDetail.Add(surveyView.surveyDetail);
                    db.SaveChanges();
                }
                else
                {
                    surveyView.surveyDetail.surveyDetailID = Convert.ToInt32(Request.Form["HDSurveyDetailID"]);
                    db.Entry(surveyView.surveyDetail).State = EntityState.Modified;
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
            surveyView.surveyDetailList = db.SurveyDetail.Where(x => x.surveyID == surveyView.survey.surveyID).ToList();
            return View(surveyView);
        }
        
        public ActionResult Create(int? id)
        {
            SurveyView objSurveyView = new SurveyView();

            objSurveyView.survey = new Survey();
            objSurveyView.surveyDetail = new SurveyDetail();

            if (id != null)
            {
                objSurveyView.surveyDetail = db.SurveyDetail.FirstOrDefault(x => x.surveyDetailID == id);
                objSurveyView.survey = db.Survey.FirstOrDefault(x => x.surveyID == id);
                objSurveyView.surveyDetailList = db.SurveyDetail.Where(u => u.surveyID == id).ToList();
            }
            else
            {
                objSurveyView.survey = new Survey();
                objSurveyView.survey.active = true;
                objSurveyView.surveyDetail = new SurveyDetail();
                objSurveyView.surveyDetailList = new List<SurveyDetail>();
            }
            return View(objSurveyView);
        }
       
        public ActionResult DeleteDetail(int id)
        {
            SurveyDetail surveyDetail = db.SurveyDetail.Find(id);
            db.SurveyDetail.Remove(surveyDetail);
            db.SaveChanges();
            return RedirectToAction("Create",id);
        }
        public ActionResult Delete(int id)
        {
            Survey survey = db.Survey.Find(id);
            db.Survey.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult getSurveyDetail(int surveyDetailID)
        {
            IList<String> OptionList = new List<String>();
            SurveyDetail objSurveyDetail = new SurveyDetail();
            objSurveyDetail = db.SurveyDetail.FirstOrDefault(x=>x.surveyDetailID==surveyDetailID);

            if (objSurveyDetail != null)
            {
                OptionList.Add(objSurveyDetail.option1);
                OptionList.Add(objSurveyDetail.option2);
                OptionList.Add(objSurveyDetail.option3);
                OptionList.Add(objSurveyDetail.option4);
                OptionList.Add(objSurveyDetail.option5);
                OptionList.Add(objSurveyDetail.option6);
                OptionList.Add(objSurveyDetail.name);
                OptionList.Add(objSurveyDetail.type);
                OptionList.Add(objSurveyDetail.surveyDetailID.ToString());
            }
            else
            {
                OptionList.Add("");
                OptionList.Add("");
                OptionList.Add("");
                OptionList.Add("");
                OptionList.Add("");
                OptionList.Add("");
                OptionList.Add("");
                OptionList.Add("");
                OptionList.Add("");
            }
            return Json(OptionList, JsonRequestBehavior.AllowGet);
        }

    }
}
