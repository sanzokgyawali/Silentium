using Abp.Application.Services;
using AnonymousChat.AppComment.Models;
using AnonymousChat.Comment.DTO;
using AnonymousChat.AppPost.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Comment
{
    public interface ICommentAppService: IApplicationService
    {
        Task<Comments> PostComment(CommentsDto commentsDto);
        Task<bool> EditComment(CommentsEditHistoryDto CommentsEditHistoryDto, int id);
        Task<bool> DeleteComment(int id);

        Task<List<CommentViewDto>> GetComments(int postId);

    }
}
