using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ChhotaNivesh.Common.Helpers
{
    public static class Utility
    {
        public static void SendEmail(Models.AppSettings appSettingManager, string to, string body, string subject, bool isHtml)
        {
            try
            {
            
                using (SmtpClient client = new SmtpClient(appSettingManager.EmailHost, Convert.ToInt32(appSettingManager.EmailPort)))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = true;
                    client.Credentials = new System.Net.NetworkCredential(appSettingManager.EmailUsername, appSettingManager.EmailPassword);
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(appSettingManager.EmailUsername, appSettingManager.EmailFromAlias);
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.Body = body;
                    mailMessage.Subject = subject;
                    mailMessage.IsBodyHtml = isHtml;
                    foreach (var address in to.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        mailMessage.To.Add(address);
                    }


                    client.Send(mailMessage);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
