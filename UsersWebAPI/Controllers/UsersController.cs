using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using UsersWebAPI.Models;
using UsersWebAPI.Repository;

namespace UsersWebAPI.Controllers
{
    [Route("api/[Controller]")]
    [Authorize()]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var user = _userRepository.Find(id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _userRepository.Add(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
                return BadRequest();

            var _user = _userRepository.Find(id);

            if (_user == null)
                return NotFound();

            _user.Name = user.Name;
            _user.Email = user.Email;

            _userRepository.Update(_user);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _userRepository.Find(id);

            if (user == null)
                NotFound();

            _userRepository.Remove(id);

            return new NoContentResult();
        }
    }
}
