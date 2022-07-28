using Microsoft.EntityFrameworkCore;


namespace UserTask1.Module
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions options) : base(options) { }
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
