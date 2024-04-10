using Abp.AutoMapper;
using AnonymousChat.AppComment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Comment.DTO
{
  
    public class CommentsDto
    {
        public int PostId { get; set; }
        public int RegisteredUsersId { get; set; }

        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
