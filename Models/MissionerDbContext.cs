using Microsoft.EntityFrameworkCore;
using Missioner.Models;
using System;

namespace Missioner.Models
{
    public class MissionerDbContext : DbContext
    {

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbContext Secret { get; set; }
        public DbContext Select { get; set; }
        public DbContext IUserExist {get; set;}


        

        

        public MissionerDbContext(DbContextOptions<MissionerDbContext> options) 
            : base(options) { }

        internal System.Threading.Tasks.Task GetUserAsync()
        {
            throw new NotImplementedException();
        }
    }

}