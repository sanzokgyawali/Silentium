using Abp.AutoMapper;
using AnonymousChat.AppPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.AppPost.DTO
{
    [AutoMapTo(typeof(Post))]
    public class PostViewDto
    {
        public int PostId { get; set; }

        public string UserName { get; set; }

        public string UserAvatar { get; set; }

        public int UserId { get; set; }

        public string Caption { get; set; }

        public string Tags { get; set; }

        public DateTime TimeofPost { get; set; }

        public int NumberOfComments { get; set; }



    }
}
