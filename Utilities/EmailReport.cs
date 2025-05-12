using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SwagLabFinalProject.Authentication;

namespace SwagLabFinalProject.Utilities
{
    public class EmailReport
    {
        public static void SendEmail()
        {
            DataDriven data = DataDriven.LoadFromJson();


            string fromEmail = data.fromEmail;
            string password = data.emailPassword;
            string toEmail = data.toEmail;
            string subject = "SwagLab1 Test Report";
            string body = "Hello,\n\nPlease find the attached Extent Report for the test execution.\n\nBest Regards,\nAutomation Team";
            string reportPath = @"D:\SwagLab1\ExtentReport\Reports05.html";

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                smtpClient.EnableSsl = true;

                // Create the email message
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(fromEmail);
                    mailMessage.To.Add(toEmail);  // Recipient's email address
                    mailMessage.Subject = subject;      // Subject of the email
                    mailMessage.Body = body;            // Body of the email

                    // Attach the report
                    if (!string.IsNullOrEmpty(reportPath))
                    {
                        Attachment attachment = new Attachment(reportPath);
                        mailMessage.Attachments.Add(attachment);
                    }

                    // Send the email
                    smtpClient.Send(mailMessage);
                }
            }
        }
    }
}
