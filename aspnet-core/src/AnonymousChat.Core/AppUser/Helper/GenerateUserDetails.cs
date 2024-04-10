using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat.AppUser.Helper
{
    public class GenerateUserDetails
    {

        public List<string> GenerateUser()
        {
            var faker = new Faker("ne");


            //generate a unique username
            var username = faker.Internet.UserName();

            var avatar = faker.Image.LoremFlickrUrl();

            return new List<string> { username, avatar };


        }
        


    }
}
