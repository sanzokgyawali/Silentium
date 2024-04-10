using Abp.AutoMapper;
using AnonymousChat.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Chat.DTO
{
    [AutoMapTo(typeof(Message))]
    public class MessageViewDto
    {

        public string MessageContent { get; set; }
        public DateTime MessageTime { get; set; }
       
        
       
        
       
        
    }
}
