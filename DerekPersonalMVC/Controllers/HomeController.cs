using DerekPersonalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DerekPersonalMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
          

            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contact)
        {
            //Create the body for the Email
            // Writin the letter
            string messageBody = string.Format($"Name: {contact.Name}<br/> Email: {contact.Email}<br/>  Message: <br/> { contact.Message}");

            //Create and configure the mail message
            //Address and put letter in envelope
            MailMessage msg = new MailMessage("no-reply@derekdev.com", //Must be an email on YOUR hosting acct
                "d.smith250@outlook.com", contact.Subject, messageBody);


            //Configure the mail message object 
            msg.IsBodyHtml = true;
            //msg.CC.Add("d.smith3800@gmail.com"); // adds a cc to the email
            //msg.Bcc.Add("instructor@centriq.com"); 
            //msg.Priority = MailPriority.High; // adds a priority to the email 

            //Create and configure the SMTP(Simple Mail Transport Protocol) client
            SmtpClient client = new SmtpClient("mail.derekdev.com");
            client.Credentials = new NetworkCredential("no-reply@derekdev.com", "*Jayhawks600");
            client.Send(msg);
            using (client)
            {
                try
                {
                    client.Send(msg);
                }
                catch
                {
                    ViewBag.ErrorMessage = "There was an error sending your email. Please try again.";
                    return View();
                }
            }

            //Send the user to the Contact Confirmation View 
            //and pass through the contact object with it 

            ViewBag.Message = "Success! Your message has been sent to me!";
         
            return View("Index", contact);
        }
    }
}