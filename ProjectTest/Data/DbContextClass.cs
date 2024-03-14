using Microsoft.EntityFrameworkCore;
using ProjectTest.Models;

namespace ProjectTest.Data
{
    public class DbContextClass:DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("DbStoredTest");
        }

        public DbSet<UsersData.taskDetails> Tasks { get; set; } 
    }
}
