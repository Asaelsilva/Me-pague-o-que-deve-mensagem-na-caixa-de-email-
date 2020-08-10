using MePague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MePague.Controllers
{
    public class DebtController : Controller
    {
        // GET: Debt
        public ActionResult Charge()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Charge(Debtor debtor)
        {
            
            SendMail(debtor);
            return RedirectToAction("Charge");
        }



        private bool SendMail(Debtor debtor)
        {
            try
            {
                
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("Email");



                mail.CC.Add(debtor.Email);
                mail.Subject = "Pague o que deve!";
                mail.IsBodyHtml = true;
                mail.Body = "Você tem uma divida com " + debtor.Name + "<br>valor da divida: " + debtor.Totaldebt + "<br>" + debtor.Name + " não aguenta mais.<br>"
                    + debtor.Name + " tem um recado para vc. <br>" + "Recado: " + debtor.Message;


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("Email", "Senha");

                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}