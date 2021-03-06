﻿using Capstone.Models;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Email model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("loganmiller001@live.com"));  // replace with valid value 
                message.From = new MailAddress("loganmiller001@live.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "loganmiller001@live.com",  // replace with valid value
                        Password = "rakkasans13"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AutomatedMessageSoldier(Email email)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                email.Message = "Your packet has been successfully recieved. You will recieve confrimation on it's status once it has been reviewed.";
                message.To.Add(new MailAddress("loganmiller001@live.com"));  // replace with valid value 
                message.From = new MailAddress("loganmiller001@live.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, email.FromName, email.FromEmail, email.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "loganmiller001@live.com",  // replace with valid value
                        Password = "rakkasans13"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    return RedirectToAction("Index", "Soldier");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AutomatedMessageFirstSergeant(Email email)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                email.Message = "A new packet has been recieved, please long in to review it.";
                message.To.Add(new MailAddress("loganmiller001@live.com"));  // replace with valid value 
                message.From = new MailAddress("loganmiller001@live.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, email.FromName, email.FromEmail, email.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "loganmiller001@live.com",  // replace with valid value
                        Password = "rakkasans13"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    return RedirectToAction("Index", "Soldier");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ApprovalNotification(Email email, Soldier solider)
        {
            if (solider.PacketStatus == true)
            {
                if (ModelState.IsValid)
                {
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    email.Message = "Your leave application has been approved.";
                    message.To.Add(new MailAddress("loganmiller001@live.com"));  // replace with valid value 
                    message.From = new MailAddress("loganmiller001@live.com");  // replace with valid value
                    message.Subject = "Your email subject";
                    message.Body = string.Format(body, email.FromName, email.FromEmail, email.Message);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "loganmiller001@live.com",  // replace with valid value
                            Password = "rakkasans13"  // replace with valid value
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp-mail.outlook.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                        return RedirectToAction("Index", "Soldier");
                    }
                }
                return View();
            }
            if (solider.PacketStatus == false)
            {
                if (ModelState.IsValid)
                {
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    email.Message = "Your leave packet has been marked incomplete, fix yourself.";
                    message.To.Add(new MailAddress("loganmiller001@live.com"));  // replace with valid value 
                    message.From = new MailAddress("loganmiller001@live.com");  // replace with valid value
                    message.Subject = "Your email subject";
                    message.Body = string.Format(body, email.FromName, email.FromEmail, email.Message);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "loganmiller001@live.com",  // replace with valid value
                            Password = "rakkasans13"  // replace with valid value
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp-mail.outlook.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                        return RedirectToAction("Index", "Soldier");
                    }
                }
                return View();
            }
            return View();
        }
    }
}