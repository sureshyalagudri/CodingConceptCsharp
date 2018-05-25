using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 1. Message - Abstraction Class.
// 2. SystemMessage & UserMessage- Redefined Abstraction Classes.
// 3. IMessageSender- Bridge Interface.
// 4. EmailSender, WebServiceSender & MSMQ Sender- ConcreteImplementation class which implements the IMessageSender interface.

namespace BridgePattern
{
    // Abstract class
    public abstract class Message
    {
        public IMessageSender Implementer { get; set; }

        public virtual void Send(string msg)
        {
            //Console.WriteLine("Abstraction");
            Implementer.SendMessage(msg);
        }
    }

    public class SystemMessage : Message
    {
        public override void Send(string msg)
        {
            //Console.WriteLine("RefinedAbstraction");
            Implementer.SendMessage(msg);
        }
    }
    public class UserMessage : Message
    {
        public override void Send(string msg)
        {
            //Console.WriteLine("RefinedAbstraction");
            Implementer.SendMessage("UserMessage");
        }
    }


    // Abstarct Interface 
    public interface IMessageSender
    {
        void SendMessage(string msg);
    }

    // Concrete Abstract1 
    class EmailSender : IMessageSender
    {
        public void SendMessage(string msg)
        {
            Console.WriteLine("Sending Email for :" + msg);
        }
    }

    // Concrete Abstract1 
    class WebServiceSender : IMessageSender
    {
        public void SendMessage(string msg)
        {
            Console.WriteLine("Sending Web Service for :" + msg);
        }
    }

}
