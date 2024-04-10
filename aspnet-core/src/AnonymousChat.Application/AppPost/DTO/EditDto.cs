using System;

namespace AnonymousChat.AppPost.DTO
{
    public class EditDto
    {
        public int PostId { get; set; }
        public string Caption { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime EditedOn { get; set; } = DateTime.UtcNow;
    }
}
