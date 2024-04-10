using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.AppUser.Models
{
    public class AvatarChangeHistory : Entity<int>
    {
        public int RegisteredUserId { get; set; }
        public string AvatarPath { get; set; }
        public DateTime DateTimeOfStored { get; set; }
        //navigation property
        public RegisteredUsers RegisteredUser { get; set; }
    }
}
