using UserTask1.Repo;

namespace UsersTask1.models
{
    public class UserVM : BaseModel
    {

        public string FisrtName { get; set; }
        public string LastName { get; set; }
        ICollection<PostsVM> Posts { get; set; }

    }
}
