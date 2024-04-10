using Abp.Application.Services;
using AnonymousChat.AppUser.Models;
using AnonymousChat.Authorization.Users;
using AnonymousChat.Chat.DTO;
using AnonymousChat.Chat.Models;
using AnonymousChat.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Messaging;

namespace AnonymousChat.Chat
{
    public class ChatAppService : ApplicationService, IChatAppService
    {

        private readonly AnonymousChatDbContext _context;

        public ChatAppService(AnonymousChatDbContext context)
        {
            _context = context; 
        }
        public Task<bool> SendPrivateMessage(string message, int receiverId)
        {

            var senderId = 4;   //get the user id from cookies
            var sender = _context.tbl_RegisteredUsers.FirstOrDefault(e => e.Id == senderId);

            var receiver = _context.tbl_RegisteredUsers.FirstOrDefault(e => e.Id == receiverId);

            var privateObj = new PrivateChat
            {
                Receiver = receiver,
               


            };

            var result= _context.tbl_PrivateChat.Add(privateObj);
            _context.SaveChanges();


            var msgObj=new Models.Message
            {
                MessageContent= message,
                MessageTime=DateTime.Now,
                IsPrivate=true,
                Sender=sender,
                PrivateChat=privateObj
                
                

                
            };
             var result1= _context.tbl_Message.Add(msgObj);
            _context.SaveChanges();
            return Task.FromResult(true);
             
          




           
        }


        public Task<List<MessageViewDto>> GetMessages(int receiverId, bool isGroup) 
        {
            var requestSenderId = 1;   //get the user id from cookies

            if (isGroup)
            {
                var result = _context.tbl_Message
                .Where(e => e.GroupChat.GroupDetail.Id==receiverId)
                .Select(e => new MessageViewDto
                {
                    MessageContent = e.MessageContent,
                    MessageTime = e.MessageTime,

                })
                .ToList();
                return Task.FromResult(result);
            }
            else
            {
                var result = _context.tbl_Message
                .Where(e => (e.Sender.Id == requestSenderId && e.PrivateChat.Receiver.Id == receiverId) || (e.Sender.Id == receiverId && e.PrivateChat.Receiver.Id == requestSenderId))
                .Select(e => new MessageViewDto
                {
                    MessageContent = e.MessageContent,
                    MessageTime = e.MessageTime,

                })
                .OrderByDescending(x => x.MessageTime)

                .ToList();
                return Task.FromResult(result);
            }

           
        }
        



        public async Task<List<ChatHistoryDto>> GetChatHistory() 
        {
            int requestSenderId = 4; // Get the user id from cookies or jwt

            var chatHistory = await _context.tbl_Message
                
                .Include(x => x.Sender)
                .Include(x => x.PrivateChat.Receiver)
                .Include(x => x.GroupChat.GroupDetail)

                .Where(x => (x.Sender.Id == requestSenderId || x.PrivateChat.Receiver.Id == requestSenderId)
                || (x.GroupChat.GroupDetail.Members.Any(x => x.Id == requestSenderId)))
                .OrderByDescending(x => x.MessageTime)
                .ToListAsync();

           
            var result = chatHistory
                .Select(message => new ChatHistoryDto
                {
                    Id = message.IsPrivate ? 
                    (message.Sender.Id == requestSenderId ? message.PrivateChat.Receiver.Id : message.Sender.Id )
                    : message.GroupChat.Id  ,

                    ChatHeadName = message.IsPrivate ?
                    (message.Sender.Id == requestSenderId ? message.PrivateChat.Receiver.AnonymousName : message.Sender.AnonymousName)
                    : message.GroupChat.GroupDetail.GroupName,


                    ChatHeadImage = message.IsPrivate ?
                    (message.Sender.Id == requestSenderId ? message.PrivateChat.Receiver.CurrentAvatarPath : message.Sender.CurrentAvatarPath)
                    : null
                })

                .ToList();
       
           
            var distinctResult = result.GroupBy(dto => new { dto.Id, dto.ChatHeadName, dto.ChatHeadImage })
                     .Select(group => group.First())
                       .ToList();

            return distinctResult;
        }
        



        //for groups
        public Task<bool> AddMemberToGroup(int groupId, int memberId)  
        {
            //finding the group

            var group=_context.tbl_GroupDetails.FirstOrDefault(e => e.Id == groupId);

            var newMember = _context.tbl_RegisteredUsers.Include(x=>x.GroupDetails).FirstOrDefault(e => e.Id == memberId);

            newMember.GroupDetails.Add(group);
           
            _context.SaveChanges();

            return Task.FromResult(true);



        }

        public Task<bool> CreateGroup(string groupName,int secondMember) 
        {
            var requestSenderId = 1;   //get the user id from cookies
            var sender = _context.tbl_RegisteredUsers


               .FirstOrDefault(e => e.Id == requestSenderId);

            var nextMember = _context.tbl_RegisteredUsers
                
                .FirstOrDefault(e => e.Id == secondMember);

           

            var group=new GroupDetails
            {
                GroupName=groupName,
                Members=new List<RegisteredUsers>() {sender,nextMember}

               
            };

            var result = _context.tbl_GroupDetails.Add(group);
            _context.SaveChanges();


           


           
            

            

           
           

            return Task.FromResult(true);

           

           
           

          


           
        }


        

        public Task<bool> SendGroupMessage(string message, int groupId)
        {

            var messageSenderId = 1;

            

            var group = _context.tbl_GroupDetails.FirstOrDefault(e => e.Id == groupId);

            var sender = _context.tbl_RegisteredUsers.FirstOrDefault(e => e.Id == messageSenderId);

           var messageObj=new Models.Message
           {
                MessageContent=message,
                MessageTime=DateTime.Now,
                IsPrivate=false,
                Sender=sender,
                GroupChat=new GroupChat { GroupDetail=group}
            };

            _context.tbl_Message.Add(messageObj);
            _context.SaveChanges();
            return Task.FromResult(true);


            
        }


        public Task<bool> DeleteGroup(int groupId) //not implemented
        {
            throw new NotImplementedException();
        }



        public Task<bool> RemoveMemberFromGroup(int groupId, int memberId)//not implemented
        {
            throw new NotImplementedException();
        }




        
    }
}
