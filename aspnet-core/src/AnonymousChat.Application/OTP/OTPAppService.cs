using Abp.Application.Services;
using AnonymousChat.AppUser.Helper;
using AnonymousChat.AppUser.Models;
using AnonymousChat.EntityFrameworkCore;
using AnonymousChat.OTP.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace AnonymousChat.OTP
{
    public class OTPAppService : ApplicationService, IOTPAppService
    {
        private readonly IMemoryCache _cache;
        private readonly GenerateOTP _otp;
        private readonly IConfiguration _appConfig;
        private readonly GenerateUserDetails _userDetails;
        //private readonly IRepository _repo;
        private readonly AnonymousChatDbContext _context;
        private readonly JWT _jwt;


        public OTPAppService(IMemoryCache cache, GenerateOTP otp, IConfiguration appConfig, GenerateUserDetails userDetails, AnonymousChatDbContext context, JWT jwt)
        {
            _cache = cache;
            _otp = otp;
            _appConfig = appConfig;
            _userDetails = userDetails;
            _context = context;
            _jwt = jwt;




        }




        public void SendOTP([FromQuery] string userPhoneNumber)
        {

            //generate OTP
            var otp = _otp.Generate();




            //store OTP in cache
            _cache.Set(userPhoneNumber, otp, TimeSpan.FromMinutes(60));

            //send OTP to user via SMS
            string accountSID = _appConfig["Twilio:AccountSID"];
            string authToken = _appConfig["Twilio:AuthToken"];
            PhoneNumber fromNumber = _appConfig["Twilio:PhoneNumber"];

            // Create a Twilio client
            TwilioClient.Init(accountSID, authToken);

            // The phone number where you want to send the OTP
            PhoneNumber toPhoneNumber = new PhoneNumber(userPhoneNumber);

            // Compose the message with the OTP
            string messageBody = $"Your OTP for Silentium is: {otp}";

            // Send the OTP via Twilio
            MessageResource.Create(
                to: toPhoneNumber,
                from: fromNumber,
                body: messageBody);

            // return Task.CompletedTask;


            //throw new NotImplementedException();
        }



        public OTPVerifiedDTO GetVerifyOTP(string userPhoneNumber, string OTP)
        {

            List<string> userDetails = new List<string>();

            //get otp from cache
            var otpFromCache = _cache.Get<string>(userPhoneNumber);

            //verify the otp

            if (otpFromCache == OTP)
            {

                //remove the otp from the cache

                //uncomment the below code to clear cache
                // _cache.Remove(userPhoneNumber);




                //check if the user is returning user or new user
                var doesUserExist = _context.tbl_RegisteredUsers.Where(a => a.PhoneNumber == userPhoneNumber).FirstOrDefault();

                if (doesUserExist == null)
                {
                    //get userdetails

                    userDetails = _userDetails.GenerateUser();

                    //save the user to the database
                    var user = new RegisteredUsers
                    {
                        PhoneNumber = userPhoneNumber,
                        AnonymousName = userDetails[0],
                        CurrentAvatarPath = userDetails[1],


                    };

                    _context.tbl_RegisteredUsers.Add(user);
                    _context.SaveChanges();
                }

                //login the user
                var signinUser = _context.tbl_RegisteredUsers.FirstOrDefault(a => a.PhoneNumber == userPhoneNumber);
                var history = new LoginHistory
                {
                    RegisteredUserId = signinUser.Id,
                    //LoginFromLat = 8.9,
                    //LoginFromLong = 5.6,
                    LoginDateTime = DateTime.UtcNow,
                    OTP = OTP

                };





                _context.tbl_LoginHistory.Add(history);
                var saved = _context.SaveChanges();

                var avatar = history.RegisteredUser.CurrentAvatarPath;
                var name = history.RegisteredUser.AnonymousName;

                if (saved > 0)
                {
                    //create jwt

                    var token = _jwt.GenerateJWT(Convert.ToString(signinUser.Id));

                    var result = new OTPVerifiedDTO
                    {
                        Token = token,
                        AnonymousName = name,
                        Avatar = avatar

                    };





                    //add token to the cookie or return as a string to frontend




                    return result;





                }








                return null;
















            }

            return null;


            throw new NotImplementedException();
        }
    }
}
