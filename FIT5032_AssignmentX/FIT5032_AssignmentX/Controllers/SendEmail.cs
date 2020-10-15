using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

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
    }
}