using ServiceDesk_Reperation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceDesk_Reperation.DBConnect
{
    class Mail
    {

        public void SendMail(string Emne, string Body, string Mail, string Person)
        {
            var fromAddress = new MailAddress("tec.gruppe14@gmail.com", "Gruppe14");
            var toAddress = new MailAddress(Mail, Person);
            const string fromPassword = "kodeord0";
            string subject = Emne;
            string body = "";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Email blev sendt!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Email blev ALDRIG NOGLE SIDEN SENDT!");
                }
                
            }
        }
    }
}
