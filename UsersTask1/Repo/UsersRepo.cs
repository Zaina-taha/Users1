using Microsoft.EntityFrameworkCore;
using UserTask1.Module;
namespace UserTask1.Repo
{
    public class UsersRepo : GenRepo<Users>, IUsers
    {
        public UsersRepo(UsersContext context) : base(context)
        {

        }

        //public new List<Users>? GetAll()
        //{
        //    return _context.Users.Include(c => c.Posts).ToList();
        //}


    }
}

