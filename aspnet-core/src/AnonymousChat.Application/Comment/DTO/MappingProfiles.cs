using AnonymousChat.AppComment.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Comment.DTO
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
          this.CreateMap<Comments, CommentsDto>().ReverseMap();
            this.CreateMap<CommentsEditHistory, CommentsEditHistoryDto>().ReverseMap();


        }
    }
}
