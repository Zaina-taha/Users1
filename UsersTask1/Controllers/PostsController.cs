using Microsoft.AspNetCore.Http;
using UserTask1.Module;
using UserTask1.Repo;
using Microsoft.AspNetCore.Mvc;

namespace UserTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public IPosts _posts;
        public PostsController(IPosts posts)
        {
            _posts = posts;
        }

        [HttpGet]
        public ActionResult<List<Posts>> GetALL()
        {
            return _posts.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Posts> Get(int id)
        {
            var posts = _posts.Get(id);
            if (posts == null)
                return NotFound();
            return posts;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var posts = _posts.Get(id);
            if (posts == null)
                return NotFound();
            _posts.Delete(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult Create(Posts posts)
        {

            _posts.Add(posts);
            return Ok();

        }
        [HttpPut]
        public ActionResult Update(Posts posts)
        {
            var _post = _posts.Get(posts.Id);
            if (_post == null)
                return NotFound();
            _posts.Update(posts);
            return Ok();
        }
    }
}

