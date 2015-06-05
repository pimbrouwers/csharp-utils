using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpUtilities
{
    public static class Utils
    {
        /// <summary>
        /// Generic function to send emails
        /// Relies on SMTP settings being configured properly in App.Config
        /// </summary>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="emails"></param>
        /// <param name="isHtml"></param>
        /// <param name="attachments"></param>
        public static void SendEmail(string from, string subject, string body, List<string> emails, bool isHtml = true, List<string> attachments = null)
        {
            using (SmtpClient mailer = new SmtpClient())
            {
                using (MailMessage msg = new MailMessage())
                {
                    try
                    {

                        msg.From = new MailAddress(from);

                        foreach (string email in emails)
                        {
                            Regex regex = new Regex(@"^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$");
                            Match match = regex.Match(email);

                            if (match.Success)
                                msg.To.Add(email);
                        }


                        msg.Subject = subject;

                        msg.IsBodyHtml = true;
                        msg.Body = body;

                        //attachments
                        if (attachments != null)
                        {
                            foreach (string attachment in attachments)
                            {
                                if (File.Exists(attachment))
                                {
                                    Attachment a = new Attachment(attachment);

                                    msg.Attachments.Add(a);
                                }
                            }
                        }


                        mailer.Send(msg);


                    }
                    catch (SmtpException ex)
                    {
                        throw new ApplicationException(ex.ToString());
                    }
                }

            }
        }
    }
}
