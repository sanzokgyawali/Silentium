using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.AppUser.Helper
{
    public class GenerateOTP
    {
        public string Generate()
        {
            Random random = new Random();
            var otp = random.Next(1000, 9999).ToString();
            return otp;
        }
    }
}
