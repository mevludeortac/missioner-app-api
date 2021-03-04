using System;
namespace Missioner.Models
{
    public class User
    {
        public Int64 id { get; set;}

        public Int64 phone_number { get; set;}
        public string name { get; set;}
        public string surname { get; set;}
        public string email { get; set; }
        public string password { get; set;}
        public string profile_photo { get; set;}
        public  bool is_online {get; set;}
        public string token { get; set; }

    }
}
