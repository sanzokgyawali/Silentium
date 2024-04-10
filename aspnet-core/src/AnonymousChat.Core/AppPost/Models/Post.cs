using Abp.Domain.Entities;
using AnonymousChat.AppComment.Models;
using AnonymousChat.AppUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.AppPost.Models
{
    public class Post:Entity<int>
    {
        public int RegisteredUserId { get; set; }
        public DateTime DateTimeOfPost { get; set; }
        public string Caption { get; set; }
        public string Keywords { get; set; }
        public string Tags { get; set; }


        // Navigation properties
        public RegisteredUsers RegisteredUser { get; set; }
        public ICollection<EditPostHistory> EditPostHistories { get; set; }
        public ICollection<Comments> Comments { get; set; }


    }
}
