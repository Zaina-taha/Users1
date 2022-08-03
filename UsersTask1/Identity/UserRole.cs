using Microsoft.AspNetCore.Identity;

namespace UsersTask1.Repo
{
    public  class UserRoles :IdentityRole<int>
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
