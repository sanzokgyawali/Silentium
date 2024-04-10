using Abp.Domain.Entities;
using AnonymousChat.AppUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.AppPost.Models
{
    public class EditPostHistory:Entity<int>
    {
        public int PostId { get; set; }
        public string Caption { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime EditedOn { get; set; }

        // Navigation property
        public Post Post { get; set; }
    }
}
