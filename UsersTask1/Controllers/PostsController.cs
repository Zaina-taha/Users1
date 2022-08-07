using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UsersTask1.Extensions;
using System.Security.Claims;
using UsersTask1.models;
using UserTask1.Module;
using UserTask1.Repo;

namespace UserTask1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;
        public IPosts _posts;
        public PostsController(IPosts posts, IMapper mapper)
        {
            _mapper = mapper;
            _posts = posts;
        }


        [HttpGet]
        // [XSampleActionFilter]
        public async Task<ActionResult<List<PostsVM>>> GetALL()
        {
            return await _posts.GetAll<PostsVM>();
        }
        [HttpGet("search")]
     
        public async Task<ActionResult<List<Posts>>> Search(int Page, int Size, string search)
        {
            return await _posts.Search(Page,Size,search);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<PostsVM>> Get(int id) 
        {
            var UU = _posts.Get<PostsVM>(id);
            if (UU == null)
                return NotFound();
            return await _posts.Get<PostsVM>(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {

            await _posts.Delete(id);
        }
        [HttpPost]
        public async  Task Create(PostsVM postsvm)
        {
            var use = _mapper.Map<Posts>(postsvm);
            var idClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
            var id_u = idClaim?.Value;
            use.UserId = Convert.ToInt32(id_u);
            
            await _posts.Add(use, Convert.ToInt32(id_u));

        }
        [HttpPut]
        public async Task Update(PostsVM posts)
        {
            var idClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
            var id_u = idClaim?.Value;
            await _posts.Update(_mapper.Map<Posts>(posts), Convert.ToInt32(id_u));
        }
    }
}

