using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Missioner.Models;
using Missioner.Helpers;
using Missioner.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Missioner.Implements
{
    public interface IUserRepository
    {
        User Authenticate(string phone_number, string password);
        IEnumerable<User> GetAll();
        
    }
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly MissionerDbContext _context;

        public UserRepository(IOptions<MissionerDbContext> context)
        {
            _context =  context.Value;
          
        }
        public UserRepository(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"]));
        }

        public User Authenticate(int phone_number, int password)
        {
             var user = _context.Users.FirstOrDefault(user => (user.id == phone_number) && (user.id == password));
            // Kullanici bulunamadıysa null döner.
            if (user == null)
                return null;

            // Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            // Sifre null olarak gonderilir.
            user.password = null;

            return user; 
        }
        
        

        public User Authenticate(string phone_number, string password)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        // public IEnumerable<User> GetAll()
        //{
        // Kullanicilar sifre olmadan dondurulur.
        //return _context.Select(id => {
        //  id.password = null;
        // return x;
        // });
        // }
    }
}