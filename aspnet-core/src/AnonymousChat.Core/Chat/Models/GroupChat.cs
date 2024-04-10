using Abp.Domain.Entities;
using AnonymousChat.AppUser.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Chat.Models
{
    public class GroupChat:Entity<int>

    {
        [ForeignKey("GroupDetailId")]
       public GroupDetails GroupDetail { get; set; }

        public ICollection<Message> Messages { get; set; }

    }
}
