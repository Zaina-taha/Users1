using System.ComponentModel.DataAnnotations;
using UserTask1.Repo;

namespace UserTask1.Module
{
    public class Users : BaseModel
    {

        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public ICollection<Posts> Posts { get; set; }

    }
}
