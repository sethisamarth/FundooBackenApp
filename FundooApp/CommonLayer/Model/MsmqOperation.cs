using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class MsmqOperation
    {         
        MessageQueue msmq = new MessageQueue();

        public void Sender(string token)
        {
            msmq.Path = @".\private$\Tokens";


            if(MessageQueue.Exists(msmq.Path))
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

        }
    }
}
