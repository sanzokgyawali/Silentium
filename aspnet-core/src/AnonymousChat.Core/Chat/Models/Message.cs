using Abp.Domain.Entities;
using AnonymousChat.AppUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Chat.Models
{
    public class Message: Entity<int>
    {
        public  string MessageContent { get; set; }
        public DateTime MessageTime { get; set; }
        public RegisteredUsers Sender { get; set; }
        
        public Boolean IsPrivate { get; set; }

        public GroupChat? GroupChat { get; set; }
        public PrivateChat? PrivateChat { get; set; }

    }
}
