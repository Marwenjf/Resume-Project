using Limilabs.Client.SMTP;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using Limilabs.Mail.MIME;
using Resume.Context;
using Resume.Models;
using Resume.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public class MailController : Controller
    {
        private const string _server = "mail.ontonomia.com";
        private const string _user = "tyouba@ontonomia.com";
        private const string _password = "mta641994";

        static void send(string subject, User to)
        {
            try
            {
                MailBuilder builder = new MailBuilder();
                builder.Html = @"Html with an image: <img src=""cid:lena"" />";
                builder.Subject = subject;
             

                MimeData visual = builder.AddVisual(HostingEnvironment.MapPath("~/Images/logo_2.png"));
                visual.ContentId = "lena";

                MimeData attachment = builder.AddAttachment(@"C:\Users\User\Desktop\Attachment.txt");
                attachment.FileName = "document.doc";

                builder.From.Add(new MailBox("tyouba@ontonomia.com"));
                builder.To.Add(new MailBox(to.Email));
                //builder.To.Add(new MailBox("benothmanzied6@gmail.com"));
                IMail email = builder.Create();

                using (Smtp smtp = new Smtp())
                {
                    smtp.Connect(_server);       // or ConnectSSL for SSL
                    smtp.UseBestLogin(_user, _password);

                    smtp.SendMessage(email);

                    smtp.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        OntomagContext db = new OntomagContext();
        // GET: Mail
        public ActionResult Index()
        {
            return View(db.Mails.ToList());
        }

        // GET: Mail/Details/5
        public ActionResult Details(int id)
        {
            Models.Mail mail = db.Mails.Find(id);
            return View(mail);
        }

        // GET: Mail/Create
        public ActionResult Create()
        {
            var users = db.Users.ToList();
            var mailViewModel = new MailViewModel();
            mailViewModel.users = users;
            return View(mailViewModel);
        }

        // POST: Mail/Create
        [HttpPost]
        public ActionResult Create(MailViewModel mailVM)
        {
            try
            {
                User user = db.Users.Find(mailVM.SelectedValue);
                Models.Mail mail = new Models.Mail
                {
                    Subject = mailVM.Subject,
                    To = user,
                    Body = mailVM.Body
                };
                if (ModelState.IsValid)
                {
                    db.Mails.Add(mail);
                    db.SaveChanges();
                    send(mail.Subject,mail.To);
                    //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    //MailMessage message = new MailMessage();
                    ////message.IsBodyHtml = true;
                    //// message.Priority = MailPriority.High;
                    //message.Subject = mail.Subject;
                    //message.To.Add(mail.To.Email);  // replace with valid value 
                    //message.From = new System.Net.Mail.MailAddress("tyouba@ontonomia.com");  // replace with valid value
                    //                                                                         //  message.Subject = "Your email subject";
                    //message.Body = string.Format(body, "ontonomia", "tyouba@ontonomia.com", mail.Body);
                    ////  message.IsBodyHtml = false;

                    //SmtpClient smtp = new SmtpClient(_server);

                    ////smtp.Host = _server;
                    //smtp.Port = 465;
                    //smtp.Credentials = new System.Net.NetworkCredential(_user, _password);

                    //smtp.EnableSsl = true;
                    //smtp.Timeout = 20000;
                    //smtp.Send(message);
                    return RedirectToAction("Index");


                }

                return View(mailVM);
            }
            catch (Exception)
            {
                return View(mailVM);
            }
        }

        // GET: Mail/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Mail mail = db.Mails.Find(id);
            if (mail != null)
            {
                return View(mail);
            }
            return RedirectToAction("Index");
        }

        // POST: Mail/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Mail mail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(mail).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(mail.MailId);
            }
            catch
            {
                return View();
            }
        }

        // GET: Mail/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Mail mail = db.Mails.Find(id);
            return View(mail);
        }

        // POST: Mail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.Mail mail)
        {
            try
            {
                Models.Mail deletedMail = db.Mails.Find(id);
                if (deletedMail != null)
                {
                    db.Mails.Remove(deletedMail);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(id);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SendMail(int id)
        {
            Models.Mail mail = db.Mails.Find(id);
            return View(mail);
        }
        public ActionResult SendMailCondidat()
        {
            return View();
        }
    }
}