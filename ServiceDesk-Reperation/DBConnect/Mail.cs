using ServiceDesk_Reperation.Model;
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

        public void SendMail(string Emne, Case sag, string Body, string Mail, string Person)
        {
            var fromAddress = new MailAddress("tec.gruppe14@gmail.com", "Gruppe14");
            var toAddress = new MailAddress(Mail, Person);
            const string fromPassword = "kodeord0";
            string subject = Emne;
            string body = CreateBody(sag, Body);
            

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
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                    MessageBox.Show("Email blev sendt!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Email blev ALDRIG NOGLE SIDEN SENDT!");
                }
                
            }
        }

        public string CreateBody( Case sag, String broedtekst)
        {
            string body = System.IO.File.ReadAllText(@"Resources\body.html");
            string vare = System.IO.File.ReadAllText(@"Resources\vare.html");

            string allevare = null;
            double pris = 225;

            foreach (Part item in sag.Parts)
            {
                string temp = vare;
                temp = temp.Replace("///Vare///",item.PartName);
                temp = temp.Replace("///status///", item.Status.Status);
                temp = temp.Replace("///pris///", item.Price.ToString());
                allevare += temp;
                pris += item.Price;
            }

            body = body.Replace("///vare///", allevare);
            body = body.Replace("///broedtekst///", broedtekst);
            body = body.Replace("///ordernr///", sag.ID.ToString());
            body = body.Replace("///navn///", sag.Customer.Name);
            body = body.Replace("///totalpris///", pris.ToString());

            return body;
        }
    }
}
