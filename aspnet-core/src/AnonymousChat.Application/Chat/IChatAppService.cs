using Abp.Application.Services;
using AnonymousChat.Chat.DTO;
using AnonymousChat.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Chat
{
    public interface IChatAppService:IApplicationService
    {
        //for private chat

        public Task<bool> SendPrivateMessage(string message, int receiverId);

        //gets all the messages for the two users and groups
       


        public Task<List<MessageViewDto>> GetMessages(int receiverId,bool isGroup);





        //gets all the chat history of the user
       

        public Task<List<ChatHistoryDto>> GetChatHistory();   








        //All the below methods are for group chat

        public Task<bool> SendGroupMessage(string message, int groupId);


        //gets all the group messages

        public Task<bool> CreateGroup(string groupName, int secondMember);

        public Task<bool> AddMemberToGroup(int groupId, int memberId);  // MemberId is the id of the user to be added to the group
        //can add 1 member at a time

        public Task<bool> RemoveMemberFromGroup(int groupId, int memberId); // MemberId is the id of the user to be removed from the group

        public Task<bool> DeleteGroup(int groupId);






    }
}
