using Microsoft.AspNetCore.Mvc;
using System.Collections;
using UsersWebAPI.Repository;

namespace UsersWebAPI.Controllers
{
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
    }
}
