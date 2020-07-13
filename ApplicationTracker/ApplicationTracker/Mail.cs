using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using MailKit.Security;
using ApplicationTracker.Models;

namespace ApplicationTracker
{
    public class Mail 
    {
        public string email;
        public string password;
        public string username;
        public string host;
        public string testemail;
        public string testname;
        /// <summary>
        /// mail individual applicant ApplicationIndexViewModel - applications that need follow up in 7 - 10 days, interviews for the week, thank you notes
        /// </summary>
        /// 
        
        public Mail()
        {
            email = MailCreds.email;
            password = MailCreds.password;
            username = MailCreds.username;
            host = MailCreds.host;
            testemail = MailCreds.testemail;
            testname = MailCreds.testname;
        }
        
        public void SendWeeklyEmail(/*Applicant applicant, ApplicationIndexViewModel applicationIndexViewModel*/) //can make a bool to check if sent then retry or log error
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress ("Application Tracker", email));
            //message.From.Add(new MailboxAddress ("ApplicationTracker", "applitrackr@gmail.com"));
            message.To.Add(new MailboxAddress(testname, testemail));
            //message.To.Add(new MailboxAddress(applicant.FirstName + " " + applicant.LastName, applicant.Email));
            message.Subject = "Week in Preview";

            message.Body = new TextPart("plain")
            {
                Text = @"Hi " + testname + ",\n" +
                //Text = @"Hi " + applicant.FirstName + ",\n" +

                "You have the following applications to follow up on this week: \n" +
                //+ BodyBuilder
                //applicationIndexViewModel.UpcomingApplications + 
                "\n You have the follow interviews this week: \n" 
                
                //+ applicationIndexViewModel.UpcomingInterviews
            };
            
            using (var client = new SmtpClient())
            {
                client.Connect("smtp." + host, 587, false);
                client.Authenticate(username, password);
                client.Send(message);
                client.Disconnect(true);

            }
        }
    }
}
