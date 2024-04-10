using Abp.Domain.Entities;
using AnonymousChat.AppUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Chat.Models
{
    public class GroupDetails:Entity<int>
    {
        public string GroupName { get; set; }

        public ICollection<RegisteredUsers> Members { get; set; }

      

        public GroupChat GroupChat { get; set; }
    }
}
