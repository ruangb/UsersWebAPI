using System.Collections.Generic;
using System.Linq;
using UsersWebAPI.Models;

namespace UsersWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User Find(long id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Remove(long id)
        {
            _context.Remove(_context.Users.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
