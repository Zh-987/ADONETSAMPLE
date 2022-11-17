using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADONETExample.Models
{
    public class Chat
    {
        public List<ChatUsers> User;

        public List<ChatMessage> Messages; 

        public Chat()
        {
            User = new List<ChatUsers>();
            Messages = new List<ChatMessage>();

            Messages.Add(new ChatMessage()
            {
                Text = "Чат запущено, время:" + DateTime.Now
            }
                );
        }
        public class ChatUsers
        {
            public string LoginPost;
            public string Password;
            public bool  Remember;
            public string Name;
            public DateTime Login;
            public DateTime LastVisit;

        }

        public class ChatMessage
        {
            public ChatUsers users;
            public DateTime Date = DateTime.Now;
            public string Text;
        }



    }
}