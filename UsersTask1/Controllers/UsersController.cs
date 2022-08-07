using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UsersTask1.Extensions;
using UsersTask1.models;
using UserTask1.Module;
using UserTask1.Repo;

namespace UserTask1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUsers _users;
        private readonly IMapper _mapper;
        public UsersController(IUsers users, IMapper mapper)
        {
            _mapper = mapper;
            _users = users;
        }

        [HttpGet]
        //[XSampleActionFilter]
        public async Task<ActionResult<List<UserVM>>> GetALL()
        {

            return await _users.GetAll<UserVM>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> Get(int id)
        {
            var UU = _users.Get<UserVM>(id);
            if (UU == null)
                return NotFound();
            return await _users.Get<UserVM>(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {   
           await _users.Delete(id);
        }
        [HttpPost]
        public async Task Create(UserVM userVM)
        {
            var us= _mapper.Map<Users>(userVM);
            var idClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
            var id_u = idClaim?.Value;
            await _users.Add(us, Convert.ToInt32(id_u));

        }
        [HttpPut]
        public async Task Update(int id,UserVM user)
        {
            var idClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
            var id_u = idClaim?.Value;
            await _users.Update(_mapper.Map<Users>(user), Convert.ToInt32(id_u));
        }
    }
}
