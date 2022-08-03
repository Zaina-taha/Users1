using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersTask1.Repo;

namespace UserTask1.Module
{
    public class UsersContext : IdentityDbContext<Users, UserRoles, int>
    {

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
       
        public DbSet<Users> Users
        {
            get;
            set;
        }
        public DbSet<Posts> Posts
        {
            get;
            set;
        }

    }
}
