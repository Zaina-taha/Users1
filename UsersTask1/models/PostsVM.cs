using UserTask1.Repo;

namespace UsersTask1.models
{
    public class PostsVM : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public UserVM? users { get; set; }
    }
}
