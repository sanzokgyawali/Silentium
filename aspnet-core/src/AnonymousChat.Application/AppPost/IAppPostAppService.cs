using Abp.Application.Services;
using AnonymousChat.AppPost.DTO;
using AnonymousChat.AppPost.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnonymousChat.AppPost
{
    public interface IAppPostAppService:IApplicationService
    {
       Task< Post> PostPosts(InputPostDto inputPostDto);
        Task<bool> EditPost(EditDto post, int id);
      Task <bool> DeletePost(int id );

        Task <List<PostViewDto>> GetRandomPosts();

        Task <List<PostViewDto>> GetPostsByTag(string tag);

        Task <List<PostViewDto>> GetPostsByUser();








    }
}
