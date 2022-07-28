using System.ComponentModel.DataAnnotations.Schema;
using UserTask1.Repo;

namespace UserTask1.Module
{
    public class Posts : BaseModel
    {

        public string Title { get; set; }

        [ForeignKey("Id")]
        public int Id { get; set; }

        public Users? users { get; set; }


    }
}
