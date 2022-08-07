using System.ComponentModel.DataAnnotations.Schema;
using UserTask1.Repo;

namespace UserTask1.Module
{
    public class Posts : BaseModel
    {

        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CrById { get; set; }
        public int UpById { get; set; }





        [ForeignKey("users")]
        public int UserId { get; set; }

        public Users? users { get; set; }


    }
}
