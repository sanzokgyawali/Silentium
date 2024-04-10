using Abp.Domain.Entities;
using AnonymousChat.AppUser.Models;
using AnonymousChat.AppPost.Models;
using System;
using System.Collections.Generic;

namespace AnonymousChat.AppComment.Models
{
    public class Comments:Entity<int>
    {
        public int PostId { get; set; }
        public int RegisteredUsersId { get; set; }
        public string Comment { get; set; }    
        public DateTime CreatedOn { get; set; }


        // Navigation properties
        public Post Post { get; set; }
        public RegisteredUsers RegisteredUsers { get; set; }
        public ICollection<CommentsEditHistory>CommentsEditHistories { get; set; }
    }
}
