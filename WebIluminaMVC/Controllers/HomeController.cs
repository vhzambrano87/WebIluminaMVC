using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebIluminaMVC.DataAccess;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.Controllers
{
    public class HomeController : Controller
    {
        private IluminaContext db = new IluminaContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            Session["USR_COD"] = "";
            Session["USR_NAME"] = "";
            Session["USR_OPCION"] = "[]";
            User objUser = new User();
            return View(objUser);
        }

        [HttpPost]
        public ActionResult Login(User objUser)
        {
            List<User> users = db.User.Where(u => u.username == objUser.username && u.password == objUser.password).ToList();

            if (users.Count > 0)
            {
                Session["USR_COD"] = users[0].username.ToUpper();
                Session["USR_NAME"] = "Bienvenido(a) " + users[0].name;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                objUser.result = 1;
            }
            return View(objUser);
        }

        public ActionResult Recover()
        {
            User objUser = new User();
            return View(objUser);
        }

        [HttpPost]
        public ActionResult Recover(User objUser)
        {
            Email oEmailBL = new Email();
            User oUser = new User();

            oUser = db.User.FirstOrDefault(u => u.username.ToUpper() == objUser.username.ToUpper());

            if (oUser != null)
            {
                oEmailBL.SendMail("Estimado usuario(a), su contraseña es: " + oUser.password, "Recuperación de contraseña", oUser.email, "");
                objUser.result = 1;
            }
            else
            {
                objUser.result = 2;
            }
            return View(objUser);
        }

        public ActionResult UpdatePassword()
        {
            User objUser = new User();
            return View(objUser);
        }

        [HttpPost]
        public ActionResult UpdatePassword(User objUser)
        {
            if (objUser.username == "" || objUser.password == "" || objUser.newpassword == "" || objUser.username == null || objUser.password == null || objUser.newpassword == null)
            {
                objUser.result = 3;
            }
            else
            {
                Email objEmail = new Email();
                User oUser = new User();

                oUser = db.User.FirstOrDefault(u => u.username.ToUpper() == objUser.username.ToUpper() && u.password == objUser.password);

                if (objUser != null)
                {
                    oUser.password = objUser.newpassword;
                    db.Entry(oUser).State = EntityState.Modified;
                    db.SaveChanges();
                    objUser.result = 1;
                }
                else
                {
                    objUser.result = 2;
                }
            }
            return View(objUser);

        }
    }
}