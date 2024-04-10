using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.Chat.DTO
{
    public class ChatHistoryDto
    {
        public int Id { get; set; }
        public string ChatHeadName { get; set; } //name of the user or group

        public string ChatHeadImage { get; set; } //image of the user or group

        

    }
}
