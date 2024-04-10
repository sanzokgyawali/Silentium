using Abp.AutoMapper;
using AnonymousChat.AppComment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Comment.DTO
{
    [AutoMapFrom(typeof(Comments))]
    public class CommentViewDto

    {
       
        public int RegisteredUsersId { get; set; }

        public string UserName { get; set; }

        public string UserAvatar { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
