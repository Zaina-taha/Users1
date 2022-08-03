using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UsersTask1.Repo;

namespace UserTask1.Module
{
    public class Users :IdentityUser<int>, IBaseModel
    {

        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public ICollection<Posts> Posts { get; set; }

    }
}
