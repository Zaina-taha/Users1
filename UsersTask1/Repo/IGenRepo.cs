using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UsersTask1.Repo;
using UserTask1.Module;

namespace UserTask1.Repo
{ 
    public interface IGenRepo<T> where T : class, IBaseModel
    {
        public Task<List<TVM>>? GetAll<TVM>();
        public Task<TVM>? Get<TVM>(int id) where TVM : class, IBaseModel;
        public Task Delete(int id);
        public Task<T> Add(T obj);
        public Task<T> Update(T obj);
    }

    public class GenRepo<T> : IGenRepo<T> where T : class, IBaseModel
    {
        public readonly UsersContext _context;
        public readonly IMapper _mapper;

        public GenRepo(UsersContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T obj)
        {
            _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;

        }

        public async Task Delete(int _id)
        {
            var _temp= await _context.Set<T>().FirstOrDefaultAsync(c=>c.Id==_id);
            _context.Set<T>().Remove(_temp);
         await  _context.SaveChangesAsync();

        }
            public  Task<TVM>? Get<TVM>(int id) where TVM : class, IBaseModel
            {
               return _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c=>c.Id == id);
            }


            public Task<List<TVM>> GetAll<TVM>()
            {
                return _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).ToListAsync();
            }

            public async Task<T> Update(T obj)
            {
                _context.Set<T>().Update(obj);
                _context.SaveChangesAsync();
                return obj;
            }
        }

       
    } 
