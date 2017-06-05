﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.DataAccess
{
    public sealed class DataUtil
    {
        IluminaContext db = new IluminaContext();
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static User GetUser()
        {
            return (User)HttpContext.Current.Session["USR_SESSION"];
        }
        public static bool Validation()
        {
            if (DataUtil.GetUser() == null)
                return false;
            else
                return true;
        }

        public bool ValidateOption(int user_id, int option_id)
        {
           var userRoles =  db.UserRole.Where(u=>u.userID==user_id);
            var roleOptions = db.RoleOption.Where(u=>u.optionID == option_id);
            foreach (var item in userRoles)
            {
                if (roleOptions.Where(u => u.roleID == item.roleID).Count()>0)
                    return true;
            }
            return false;
        }

        public Option GetOption(int id)
        {
            return db.Option.FirstOrDefault(u=>u.optionID == id);
        }

        public static Boolean SendMail(string mensaje, string asunto, string mailDestino, string url)
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("vhzambran87@gmail.com", "Administrador", Encoding.UTF8);
                //Aquí ponemos el asunto del correo
                mail.Subject = asunto;
                //Aquí ponemos el mensaje que incluirá el correo
                mail.Body = mensaje;
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add(mailDestino);
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                if (url != "")
                {
                    mail.Attachments.Add(new Attachment(url));
                }
                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("vhzambran87@gmail.com", "vhjjmeVH87");
                SmtpServer.EnableSsl = true;

                SmtpServer.Host = "smtp.gmail.com";

                //Logger.Write("Envío de email");
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Error Email: " + ex.Message);
                return false;
            }

        }

    }
}
