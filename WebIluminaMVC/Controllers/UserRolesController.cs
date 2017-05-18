﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebIluminaMVC.DataAccess;
using WebIluminaMVC.Model;
using WebIluminaMVC.ModelView;

namespace WebIluminaMVC.Controllers
{
    public class UserRolesController : Controller
    {
        private IluminaContext db = new IluminaContext();

        // GET: UserRoles
        public ActionResult Index(int? id)
        {
            if (id == null)
                id = 0;

            UserRoleView objUserRoleView = new UserRoleView();
            objUserRoleView.userRoleList = db.UserRole.Include(u => u.role).Include(u => u.user).Where(u=>u.user.userID==id).ToList();
            objUserRoleView.roles = db.Database.SqlQuery<Role>("select r.roleid, r.name, CAST(ISNULL((select 1 from userRoles ur where ur.userID = @userID and ur.roleID = r.roleID),0) AS BIT) selected, r.active, r.createdate, r.createuser, r.updatedate, r.updateuser from roles r where r.active = 1 ", new SqlParameter ("@userID",id)).ToList();
            objUserRoleView.user = db.User.Find(id);

            return View(objUserRoleView);
        }

        [HttpPost]
        public ActionResult Index(UserRoleView objUserRoleView)
        {
            try
            {

                var RemoveAll = db.UserRole.Where(x => x.userID == objUserRoleView.user.userID);
                db.UserRole.RemoveRange(RemoveAll);
                db.SaveChanges();

                UserRole objUserRole = new UserRole();
                foreach (var item in objUserRoleView.roles)
                {
                    if (item.selected)
                    {
                        objUserRole.userID = objUserRoleView.user.userID;
                        objUserRole.roleID = item.roleID;
                        db.UserRole.Add(objUserRole);                        
                    }
                }
                db.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            objUserRoleView.userRoleList = db.UserRole.Include(u => u.role).Include(u => u.user).Where(u => u.user.userID == objUserRoleView.user.userID).ToList();
            objUserRoleView.roles = db.Role.Where(u => u.active).ToList();
            objUserRoleView.user = db.User.Find(objUserRoleView.user.userID);
            return View(objUserRoleView);
        }

        
    }
}
