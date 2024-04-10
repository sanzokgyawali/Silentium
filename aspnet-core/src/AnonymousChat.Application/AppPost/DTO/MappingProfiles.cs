using AnonymousChat.AppPost.Models;
using AutoMapper;

namespace AnonymousChat.AppPost.DTO
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            this.CreateMap<Post, InputPostDto>().ReverseMap();
         


        }
    }
}
