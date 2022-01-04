using Experimental.System.Messaging;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Model
{
    public class MsmqOperation
    {
        string HtmlString;
        MessageQueue msmq = new MessageQueue();

        public void Sender(string token)
        {
            msmq.Path = @".\private$\Tokens";


            if (MessageQueue.Exists(msmq.Path))
            {
                MessageQueue.Create(msmq.Path);

            }
            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            msmq.ReceiveCompleted += Msmq_ReceiveCompleted;
            msmq.Send(token);
            msmq.BeginReceive();
            msmq.Close();
        }

        private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = msmq.EndReceive(e.AsyncResult);
            string token = msg.Body.ToString();
            //mail sending code smtp 

            //For a msmq reciver
            msmq.BeginReceive();
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("sj7525316@gmail.com ");
                message.To.Add(new MailAddress("sj7525316@gmail.com "));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = HtmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("sj7525316@gmail.com ", "s789456123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception)
            {
            }
        }
    }
}

