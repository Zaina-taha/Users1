using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UsersTask1.models;
using UsersTask1.Repo;
using UserTask1.Module;

namespace UserTask1.Repo
{
    public class PostsRepo : GenRepo<Posts>, IPosts
    {
        public readonly IMapper _mapper;
        public PostsRepo(UsersContext context, IMapper mapper) : base(context)
        {

            _mapper = mapper;
        }
        public async Task< List<PostsVM>> GetAll()
        {
            return await _context.Users.ProjectTo<PostsVM>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public new Task<TVM>? Get<TVM>(int id) where TVM : class, IBaseModel
        {
            return _context.Users.ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Posts>> Search(int Page, int Size, string search)
        {
           return _context.Posts.Skip(Page*Size).Take(Size).
                Where(x=>x.Title.Contains(search)).ToList();

        }





    }
}
