using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UsersTask1.models;
using UsersTask1.Repo;
using UserTask1.Module;
namespace UserTask1.Repo
{
    public class UsersRepo : GenRepo<Users>, IUsers
    {
        public readonly IMapper _mapper;
        public UsersRepo(UsersContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;

        }
        public async Task<List<UserVM>> GetAll()
        {
            return await _context.Users.ProjectTo<UserVM>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public new Task<TVM>? Get<TVM>(int id) where TVM : class, IBaseModel
        {
            return  _context.Users.ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
        }





    }
}

