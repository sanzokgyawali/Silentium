using Abp.Domain.Entities;
using AnonymousChat.AppUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Chat.Models
{
    public class PrivateChat: Entity<int>
    {

        public RegisteredUsers Receiver { get; set; }   

        public ICollection<Message> Messages { get; set; }
    }
}
