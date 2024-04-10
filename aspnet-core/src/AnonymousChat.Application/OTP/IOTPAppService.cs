using Abp.Application.Services;
using AnonymousChat.OTP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.OTP
{
    public interface IOTPAppService: IApplicationService
    {
        public void SendOTP(string userPhoneNumber);

        public OTPVerifiedDTO GetVerifyOTP(string userPhoneNumber, string OTP);


    }
}
