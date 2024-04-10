using Abp.Domain.Entities;
using System;

namespace AnonymousChat.AppComment.Models
{
    public class CommentsEditHistory : Entity<int>
    {
        public int CommentsId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
     
        
        // Navigation property

        public Comments Comments { get; set; }

    }
}
