using Abp.Application.Services;
using Abp.Events.Bus.Handlers;
using AnonymousChat.AppComment.Models;
using AnonymousChat.Comment.DTO;
using AnonymousChat.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnonymousChat.Comment
{
    public class CommentAppService:ApplicationService,ICommentAppService
    {
      
        private readonly IMapper _mapper;

        private readonly AnonymousChatDbContext _context;

        public CommentAppService(IMapper mapper, AnonymousChatDbContext context)
        {
            
            _context = context;
            _mapper = mapper;

        }

        async public Task<Comments> PostComment(CommentsDto commentsDto)
        {
            var dtoResult =  _mapper.Map<Comments>(commentsDto);
            var result = await _context.tbl_Comments.AddAsync(dtoResult);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        async public Task<bool> DeleteComment(int id)
        {
          
                var commentsResult = _context.tbl_Comments.FirstOrDefault(e => e.Id == id);
                if (commentsResult != null)
                {
                    _context.tbl_Comments.Remove(commentsResult);
                    await _context.SaveChangesAsync();
                    return true;
                }


         
            return false;
        }

        async public Task<bool> EditComment(CommentsEditHistoryDto CommentsEditHistoryDto, int id)
        {
            var commentsResult =  _context.tbl_Comments.FirstOrDefault(e => e.Id == id);
            if (commentsResult != null)
            {



                commentsResult.Comment = CommentsEditHistoryDto.Comment;
            
            _context.tbl_Comments.Update(commentsResult);
            await _context.SaveChangesAsync();

            var commentEditResult = new CommentsEditHistory
            {
                CommentsId=commentsResult.Id,
                Comment = CommentsEditHistoryDto.Comment,
                CreatedOn= commentsResult.CreatedOn,
                EditedOn=DateTime.UtcNow
            };
          await _context.tbl_CommentsEditHistory.AddAsync(commentEditResult);
            await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<List<CommentViewDto>> GetComments(int postId)
        {
            //if number of comments is 0 then limit the access of this api from frontend

            var comments=_context.tbl_Comments
                .Include(e=>e.RegisteredUsers)
                
                .Where(e => e.PostId == postId)
                .Select(e => new CommentViewDto
                {
                   
                    RegisteredUsersId = e.RegisteredUsersId,
                    Comment = e.Comment,
                    CreatedOn = e.CreatedOn,
                    UserAvatar=e.RegisteredUsers.CurrentAvatarPath,
                    UserName=e.RegisteredUsers.AnonymousName,
                    

                   

                }). 
                ToList();
           
            return Task.FromResult(comments);
        }
    }
}
