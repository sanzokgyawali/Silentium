using Abp.Domain.Entities;
using System;

namespace AnonymousChat.AppUser.Models
{
    public class LoginHistory : Entity<int>
    {
        public int RegisteredUserId { get; set; }
        public double? LoginFromLat { get; set; }
        public double? LoginFromLong { get; set; }
        public DateTime LoginDateTime { get; set; }
        public string OTP { get; set; }

        //navigation property
        public RegisteredUsers RegisteredUser { get; set; }
    }
}
