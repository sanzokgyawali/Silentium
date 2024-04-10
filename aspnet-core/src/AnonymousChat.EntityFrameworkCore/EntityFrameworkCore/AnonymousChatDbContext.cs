using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AnonymousChat.Authorization.Roles;
using AnonymousChat.Authorization.Users;
using AnonymousChat.MultiTenancy;
using AnonymousChat.AppUser.Models;
using AnonymousChat.AppPost.Models;
using AnonymousChat.AppComment.Models;
using AnonymousChat.Chat.Models;

namespace AnonymousChat.EntityFrameworkCore
{
    public class AnonymousChatDbContext : AbpZeroDbContext<Tenant, Role, User, AnonymousChatDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AnonymousChatDbContext(DbContextOptions<AnonymousChatDbContext> options)
            : base(options)
        {
        }


        // user login tables
        public DbSet<RegisteredUsers> tbl_RegisteredUsers { get; set; }
        public DbSet<AvatarChangeHistory> tbl_AvatarChangeHistory { get; set; }
        public DbSet<LoginHistory> tbl_LoginHistory { get; set; }
        public DbSet<NameChangeHistory> tbl_NameChangeHistory{ get; set; }
        

        //user post tables
        public DbSet<Post> tbl_Post { get; set; }
        public DbSet<EditPostHistory> tbl_EditPostHistory { get; set; }

        // user comment tables


        public DbSet<Comments> tbl_Comments { get; set; }
        public DbSet<CommentsEditHistory> tbl_CommentsEditHistory { get; set; }



        // chat tables
        public DbSet<GroupChat> tbl_GroupChat { get; set; }
        public DbSet<PrivateChat> tbl_PrivateChat { get; set; }
        public DbSet<Message> tbl_Message { get; set; }
        public DbSet<GroupDetails> tbl_GroupDetails { get; set; }




    }
}
