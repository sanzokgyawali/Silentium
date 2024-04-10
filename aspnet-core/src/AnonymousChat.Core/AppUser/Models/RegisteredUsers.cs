using Abp.Domain.Entities;
using AnonymousChat.AppComment.Models;
using AnonymousChat.AppPost.Models;
using AnonymousChat.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.AppUser.Models
{
    public class RegisteredUsers : Entity<int>
    {
        public string PhoneNumber { get; set; }
        public string AnonymousName { get; set; }
        public string CurrentAvatarPath { get; set; }

        //navigation properties
        public ICollection<LoginHistory> LoginHistories { get; set; }
        public ICollection<NameChangeHistory> NameChangeHistories { get; set; }
        public ICollection<AvatarChangeHistory> AvatarChangeHistories { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comments> Comments { get; set; }



       // for chat
        public ICollection<PrivateChat> PrivateChats { get; set; }

      public ICollection<GroupDetails> GroupDetails { get; set; }





    }
}
