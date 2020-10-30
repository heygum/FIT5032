using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.Entity;
using System.Net;
using FIT5032_AssignmentX.Models;
using PagedList;
using System.Web.UI.WebControls;

namespace FIT5032_AssignmentX.Controllers
{
    [ValidateInput(false)]
    public class SendEmail
    {
        private const String API_KEY = "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";

        public void Send()
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("heygum97@gmail.com", "CEO");
            var to = new EmailAddress("kxuu0025@student.monash.edu", "Boxer");
            var subject = "Report of your movePlans";
            var plainTextContent = "..";
            var htmlContent = "<p>" + "Hello, User." + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes("C:\\Users\\CJ\\Source\\Repos\\FIT5032_AssignmentX\\FIT5032_AssignmentX\\img\\small1.jpg");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("small1.jpg", file);
            var response = client.SendEmailAsync(msg);
        }

        public void Send(string content, string email)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("heygum97@gmail.com", "CEO");
            var to = new EmailAddress(email, "Boxer");
            var subject = "Send from living as a Boxer";
            var plainTextContent = "..";
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        public void Send(string name, string path, string email)
        {
            var code = Path.Combine(path, name);
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("heygum97@gmail.com", "CEO");
            var to = new EmailAddress(email, "Boxer");
            var subject = "Report of your movePlans";
            var plainTextContent = "..";
            var htmlContent = "<p>" + "Hello, User." + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes(code);
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(name, file);
            var response = client.SendEmailAsync(msg);
        }

        public void SendBulk(string content, List<string> email)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("heygum97@gmail.com", "CEO");
            var to_addr = new List<EmailAddress>();
            foreach (var e in email)
            {
                to_addr.Add(new EmailAddress(e, "Boxers"));
            }
            var subject = "Sent from Living as a Boxer";
            var plainTextContent = "..";
            var htmlContent = content;
            var bytes = File.ReadAllBytes("C:\\Users\\CJ\\Source\\Repos\\FIT5032_AssignmentX\\FIT5032_AssignmentX\\img\\small1.jpg");
            var file = Convert.ToBase64String(bytes);   
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to_addr, subject, plainTextContent, htmlContent);
            msg.AddAttachment("Hello.jpg", file);
            var response = client.SendEmailAsync(msg);
        }
    }
}