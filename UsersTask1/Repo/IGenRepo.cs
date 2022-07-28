using UserTask1.Module;

namespace UserTask1.Repo
{
    public interface IGenRepo<T> where T : class, IBaseModel
    {
        public List<T>? GetAll();
        public T? Get(int id);
        public void Delete(int id);
        public T Add(T obj);
        public T Update(T obj);
    }

    public class GenRepo<T> : IGenRepo<T> where T : class, IBaseModel
    {
        public readonly UsersContext _context;

        public GenRepo(UsersContext context)
        {
            _context = context;
        }
        public T Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;

        }

        public void Delete(int id)
        {
            var temp = Get(id);
            _context.Set<T>().Remove(temp);
        }

        public T? Get(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
            return obj;
        }
    }
}
