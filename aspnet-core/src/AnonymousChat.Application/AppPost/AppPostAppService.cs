using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using AnonymousChat.Authorization.Users;
using AnonymousChat.EntityFrameworkCore;
using AnonymousChat.AppPost.DTO;
using AnonymousChat.AppPost.Models;

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.UI;
using JetBrains.Annotations;

namespace AnonymousChat.AppPost
{
    public class AppPostAppService:ApplicationService,IAppPostAppService
    {
       
        private readonly IMapper _mapper;

        private readonly AnonymousChatDbContext _context;

        public AppPostAppService(IMapper mapper, AnonymousChatDbContext context)
        {
          
            _context = context;
            _mapper = mapper;

        }  
        /// <inheritdoc/>

        public async Task<Post> PostPosts( [FromBody] InputPostDto inputPostDto)
        {
            var userFromCookies = 1;

                var user = _mapper.Map<Post>(inputPostDto);
                user.RegisteredUserId = userFromCookies;
                 user.DateTimeOfPost = DateTime.UtcNow;
                var result = await _context.tbl_Post.AddAsync(user);
                await _context.SaveChangesAsync();
            
                 return result.Entity;


        }

        public async Task<bool> EditPost(EditDto post, int id)
        {

            var postId = await _context.tbl_Post.FirstOrDefaultAsync(a => a.Id == id);
            if (postId != null)
            {
        
                postId.Caption = post.Caption;
               
               
            var result= _context.tbl_Post.Update(postId);
               await _context.SaveChangesAsync();

                var EditPostHistory = new EditPostHistory
                {
                    PostId=postId.Id,
                    Caption = post.Caption,
                    EditedOn = DateTime.UtcNow,
                    PostedOn=postId.DateTimeOfPost,

                };
               

             await _context.tbl_EditPostHistory.AddAsync(EditPostHistory);
                await _context.SaveChangesAsync();

                return true;


            }
            return false;
        }



    public async Task<bool> DeletePost(int id)
        {
            
            var postId = await _context.tbl_Post.FirstOrDefaultAsync(a => a.Id == id);
            if (postId != null)
            {
                try
                {
                    _context.tbl_Post.Remove(postId);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    throw new UserFriendlyException("something went wrong"+e);
                }
                
                return true;

            }

        
            return false;


        }

        public Task<List<PostViewDto>> GetRandomPosts()
        {
            int userid = 2; //get the user id from cookies or jwt

            var posts= _context.tbl_Post
                .Include(a => a.RegisteredUser)
                .Include(a => a.Comments)
                .Where(a => a.RegisteredUserId!=userid)
                .OrderBy(a => Guid.NewGuid())
                .Take(10)
                .Select(a => new PostViewDto
                {
                    PostId = a.Id,
                    Caption = a.Caption,
                    NumberOfComments = a.Comments.Count,
                    Tags = a.Tags,
                    TimeofPost = a.DateTimeOfPost,
                    UserAvatar = a.RegisteredUser.CurrentAvatarPath,
                    UserName = a.RegisteredUser.AnonymousName,
                    UserId = a.RegisteredUserId

                }).ToList();

            return Task.FromResult(posts);
               




            
        }

        public Task<List<PostViewDto>> GetPostsByTag(string tag)
        {
            var posts = _context.tbl_Post
               .Include(a => a.RegisteredUser)
               .Include(a => a.Comments)
               .Where(a => a.Tags==tag)
               .OrderBy(a => Guid.NewGuid())
               .Take(10)
               .Select(a => new PostViewDto
               {
                   PostId = a.Id,
                   Caption = a.Caption,
                   NumberOfComments = a.Comments.Count,
                   Tags = a.Tags,
                   TimeofPost = a.DateTimeOfPost,
                   UserAvatar = a.RegisteredUser.CurrentAvatarPath,
                   UserName = a.RegisteredUser.AnonymousName,
                   UserId = a.RegisteredUserId

               }).ToList();

            return Task.FromResult(posts);




            
        }

        public Task<List<PostViewDto>> GetPostsByUser()
        {
            int userid = 1; //get the user id from cookies or jwt

            var posts = _context.tbl_Post
               .Include(a => a.RegisteredUser)
               .Include(a => a.Comments)
               .Where(a => a.RegisteredUserId == userid)
               .OrderByDescending(a=>a.DateTimeOfPost)
               .Take(10)
               .Select(a => new PostViewDto
               {
                   PostId = a.Id,
                   Caption = a.Caption,
                   NumberOfComments = a.Comments.Count,
                   Tags = a.Tags,
                   TimeofPost = a.DateTimeOfPost,
                   UserAvatar = a.RegisteredUser.CurrentAvatarPath,
                   UserName = a.RegisteredUser.AnonymousName,
                   UserId = a.RegisteredUserId

               }).ToList();

            return Task.FromResult(posts);
        }
    }
}
