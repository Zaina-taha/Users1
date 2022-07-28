namespace UserTask1.Repo
{
    public interface IBaseModel
    {
        public int Id { get; set; }
    }
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }
    }
}
